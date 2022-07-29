using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallStates { WHOLE, CRACKED, BROKEN}
public enum LastContact {NONE, P1, P2 }
public class Ball : MonoBehaviour
{
    public float initialSpeed;

    public float xSpeed;
    public float ySpeed;
    public float xDirection;
    public float yDirection;
    public BallStates state;

    // the amount to add when collide with water paddle
    public float waterSpeedDeduction;
    // the amount to subtract when collide with earth paddle
    public float earthSpeedAddition;
    // the amount to add in the x-direction when collide with air paddle
    public float airSpeedAddition;

    /*
        This keeps track of whole hit the ball.
    */
    public LastContact whoLastHit;

    private Rigidbody2D _rigidbody;

    private Vector3 currentVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        // initial states
        state = BallStates.WHOLE;
        whoLastHit = LastContact.NONE;
    }

    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        // reseting states
        state = BallStates.WHOLE;
        whoLastHit = LastContact.NONE;
    }

    private void OnCollisionEnter(Collision other)
    {
        bool applyPaddleDirection = true;

        // if ball collides with goal
        if ((other.gameObject.tag == "P1Goal") || (other.gameObject.tag == "P2Goal")){
            // don't apply because not colliding with paddle
            applyPaddleDirection = false;
            // no need to run the code below
            return;
        }
        
        // if ball collided with upper/lower wall, reverse y direction
        if ((other.gameObject.tag == "TopWall") || (other.gameObject.tag == "BottomWall")){
            yDirection *= -1;
            // no need to run the code below
            return;
        }

        // save who hit the ball
        PaddleUnit paddle = other.gameObject.GetComponent<PaddleUnit>();
        if (paddle.playerID == 1){
            whoLastHit = LastContact.P1;
        }else{
            whoLastHit = LastContact.P2;
        }

        // check tag on paddle
        switch(other.gameObject.tag){
            case "Earth":
                // increase speed
                xSpeed += earthSpeedAddition;
                ySpeed += earthSpeedAddition;
                break;
            case "Water":
                // normal interaction
                if (state == BallStates.WHOLE){
                    // decrease speed (WARNING: this will allow ball to have negative speed)
                    xSpeed -= waterSpeedDeduction;
                    ySpeed -= waterSpeedDeduction;
                // interaction as cracked ball
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    // deduct point from the player that broke it
                    paddle.DeductFromScore();
                    // FIXME: break ball, pause, then respawn it
                }
                break;
            case "Air": // a spike
                // removes y movement
                ySpeed = 0.0f;
                yDirection = 0.0f;
                // add air speed to x speed
                xSpeed += airSpeedAddition;
                // don't apply paddle direction to keep the straight shot
                applyPaddleDirection = false;
                break;
            case "Fire":
                // normal interaction
                if (state == BallStates.WHOLE){
                    state = BallStates.CRACKED;
                // interaction as cracked ball
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    // deduct point from the player that broke it
                    paddle.DeductFromScore();
                    // FIXME: break ball, pause, then respawn it
                }
                break;
            default:
                // do nothing
                break;
        }

        // reverse x direction
        xDirection *= -1;

        // FIXME: apply paddle movement direction to ball (this only alters the y movement)
        if (applyPaddleDirection){
            // if ball has no y direction, give it the paddle's direction
            if (yDirection == 0){
                yDirection = paddle.direction;
            }
            /*
                FIXME: is scaling needed?
                I saw that the paddle's speed is 10, while the ball's speed is 200.
            */
            // add paddle's y speed to ball's (include affect of paddle's direction)
            ySpeed += paddle.defaultSpeed;
        }
    }

    // adds random direction to the ball when spawned in
    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.initialSpeed);
    }
    public void AddForce(Vector2 force) 
    {
        _rigidbody.AddForce(force);
    }

}
