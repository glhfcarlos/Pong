using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallStates { WHOLE, CRACKED, BROKEN }
public enum LastContact { NONE, P1, P2 }
public class Ball : MonoBehaviour
{
    public ParticleSystem particleLauncher;

    public float initialSpeed;

    // these values are for the elemental force vector
    public Vector2 elementalForce;

    // the amount to add when collide with water paddle
    public float waterSpeedDeduction;
    // the amount to subtract when collide with earth paddle
    public float earthSpeedAddition;
    // the amount to add in the x-direction when collide with air paddle
    public float airSpeedAddition;
    private bool airForce;

    //This keeps track of whole hit the ball.
    public LastContact whoLastHit;
    
    public BallStates state;

    private SpriteRenderer sp;

    // for teh sprites
    public List<Sprite> ballSprites;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        // initial states
        state = BallStates.WHOLE;
        whoLastHit = LastContact.NONE;
        elementalForce = Vector3.zero;
        airForce = false;
    }

    private void Start()
    {
        ResetPosition();
        AddStartingForce();
        //Debug.Log(_rigidbody.velocity);
    }

    private void FixedUpdate(){
        //Debug.Log(_rigidbody.velocity);
    }

    void AddElementalForce(){
        // FIXME: removing the y movement causes the ball to vibrate before flying off
        if (airForce){
            // set rigidbody y movement to zero
            _rigidbody.velocity *= new Vector2(1.0f, 0.0f);
            // reset flag
            airForce = false;
        }
        // add the force to the rigidbody
        _rigidbody.AddForce(elementalForce);
        //Debug.Log("Ball: " + elementalForce.ToString());
    }

    // handle BROKEN state
    void HandleBrokenState(){
        // FIXME: shatter ball (VFX)
    }

    public void StopMovement(){
        _rigidbody.velocity = Vector2.zero;
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        // reseting states
        state = BallStates.WHOLE;
        whoLastHit = LastContact.NONE;
        sp.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // play collision sound
        FindObjectOfType<AudioManager>().Play("BallCollision");
        
        //bool applyPaddleDirection = true;

        // save who hit the ball
        PaddleUnit paddle = other.gameObject.GetComponent<PaddleUnit>();
        // if it wasn't a paddle that the ball collided into
        if (paddle == null)
            return;
        
        if (paddle.playerID == 1){
            whoLastHit = LastContact.P1;
        }else{
            whoLastHit = LastContact.P2;
        }

        // check tag on paddle
        switch(other.gameObject.tag){
            case "Earth":
                // set x direction
                if (whoLastHit == LastContact.P1){
                    elementalForce.x = 1 * earthSpeedAddition;
                }else{
                    elementalForce.x = -1 * earthSpeedAddition;
                }
                // set y direction to directon the ball is already in
                elementalForce.y = Mathf.Sign(_rigidbody.velocity.y) * earthSpeedAddition;
                //Debug.Log("earth");
                break;
            case "Water":
                // if normal interaction, decrease speed
                if (state == BallStates.WHOLE){
                    // set x direction as opposite of x direction before collision
                    if (whoLastHit == LastContact.P1){
                        elementalForce.x = -1 * waterSpeedDeduction;
                    }else{
                        elementalForce.x = 1 * waterSpeedDeduction;
                    }
                    // set y direction to directon the ball is already in
                    elementalForce.y = Mathf.Sign(_rigidbody.velocity.y) * waterSpeedDeduction;
                // if interacting as cracked ball, break
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    Debug.Log("broken");
                    HandleBrokenState();
                }
                //Debug.Log("water");
                break;
            case "Air": // a spike
                // add no y movement to elemental force
                elementalForce.y = 0.0f;
                // set x direction as opposite of x direction before collision
                if (whoLastHit == LastContact.P1){
                    elementalForce.x = 1 * airSpeedAddition;
                }else{
                    elementalForce.x = -1 * airSpeedAddition;
                }
                // set flag
                airForce = true;
                break;
            case "Fire":
                // reset the elemental force, it won't be used here
                elementalForce = Vector2.zero;
                // if normal interaction, crack
                if (state == BallStates.WHOLE){
                    state = BallStates.CRACKED;
                    // FIXME: change sprite instead
                    sp.color = Color.red;
                    Debug.Log("cracked");
                // if interacting as cracked ball, break
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    Debug.Log("broken");
                    HandleBrokenState();
                }
                break;
            default:
                // do nothing
                break;
        }

        /*
        FIXME: is scaling needed?
        I saw that the paddle's speed is 10, while the ball's speed is 200.

        // FIXME: apply paddle movement direction to ball (this only alters the y movement)
        if (applyPaddleDirection){
            // if ball has no y direction, give it the paddle's direction
            if (yDirection == 0){
                yDirection = paddle.direction;
            }
            // add paddle's y speed to ball's (include affect of paddle's direction)
            ySpeed += paddle.defaultSpeed;
        }

        */

        AddElementalForce();
    }

    // adds random direction to the ball when spawned in
    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.initialSpeed);
        elementalForce = new Vector2(initialSpeed * x, initialSpeed * y);
    }
    public void AddForce(Vector2 force) 
    {
        _rigidbody.AddForce(force);
    }

}
