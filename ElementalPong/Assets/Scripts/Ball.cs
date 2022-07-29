using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallStates { WHOLE, CRACKED, BROKEN}
public enum LastContact {NONE, P1, P2 }
public class Ball : MonoBehaviour
{
    public float initialSpeed;

    // these values are for the elemental force vector
    public float xSpeed;
    public float ySpeed;
    public float xDirection;
    public float yDirection;

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

    private Rigidbody2D _rigidbody;

    private Vector2 elementalForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        Debug.Log(_rigidbody.velocity);
    }

    void AddElementalForce(){
        // setup elemental force vector
        elementalForce.x = xDirection * xSpeed;
        elementalForce.y = yDirection * ySpeed;
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

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        // reseting states
        state = BallStates.WHOLE;
        whoLastHit = LastContact.NONE;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
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
                // increase speed
                xSpeed = earthSpeedAddition;
                ySpeed = earthSpeedAddition;
                // set x direction
                if (whoLastHit == LastContact.P1){
                    xDirection = 1;
                }else{
                    xDirection = -1;
                }
                // set y direction to directon the ball is already in
                yDirection = Mathf.Sign(_rigidbody.velocity.y);
                //Debug.Log("earth");
                break;
            case "Water":
                // if normal interaction, decrease speed
                if (state == BallStates.WHOLE){
                    xSpeed = waterSpeedDeduction;
                    ySpeed = waterSpeedDeduction;
                    // set x direction as opposite of x direction before collision
                    xDirection = Mathf.Sign(_rigidbody.velocity.x) * -1;
                    // set y direction to directon the ball is already in
                    yDirection = Mathf.Sign(_rigidbody.velocity.y);
                // if interacting as cracked ball, break
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    // deduct point from player that broke it
                    paddle.DeductFromScore();
                    // FIXME: reset ball
                    Debug.Log("broken");
                }
                //Debug.Log("water");
                break;
            case "Air": // a spike
                // add no y movement to elemental force
                ySpeed = 0;
                yDirection = 0;
                // add rigidbody y speed to elemental force x speed
                xSpeed = Mathf.Abs(_rigidbody.velocity.y);
                // set elemental force x speed as air speed
                xSpeed += airSpeedAddition;
                // set x direction as opposite of x direction before collision
                xDirection = -1 * Mathf.Sign(_rigidbody.velocity.x);
                // set flag
                airForce = true;
                //Debug.Log("air");
                break;
            case "Fire":
                // reset the elemental force, it won't be used here
                xSpeed = 0.0f;
                ySpeed = 0.0f;
                xDirection = 0.0f;
                yDirection = 0.0f;
                // FIXME: double collision detection
                // if normal interaction, crack
                if (state == BallStates.WHOLE){
                    state = BallStates.CRACKED;
                    Debug.Log("cracked");
                // if interacting as cracked ball, break
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    // deduct point from player that broke it
                    paddle.DeductFromScore();
                    // FIXME: reset ball
                    Debug.Log("broken");
                }
                Debug.Log("fire");
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
        xSpeed = initialSpeed;
        ySpeed = xSpeed;
        xDirection = x;
        yDirection = y;
    }
    public void AddForce(Vector2 force) 
    {
        _rigidbody.AddForce(force);
    }

}
