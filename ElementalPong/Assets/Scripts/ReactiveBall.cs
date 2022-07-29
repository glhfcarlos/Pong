using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallStates { WHOLE, CRACKED, BROKEN}
public enum LastContact {NONE, P1, P2 }
public class ReactiveBall : MonoBehaviour
{
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

    private Rigidbody2D rb;

    private Vector2 currentVelocity;

    void Awake(){
        // FIXME: have ball fly to one side of the screen on startup
        currentVelocity = Vector2.zero;

        // initial states
        state = BallStates.WHOLE;
        whoLastHit = LastContact.NONE;
    }

    void FixedUpdate(){
        // FIXME: update velocity
        // apply force
        rb.AddForce(currentVelocity);
    }

    void OnCollisionEnter2D(Collision2D col){
        bool applyPaddleDirection = true;

        // FIXME: account for collision with walls
        // if ball collides with goal
        if ((col.gameObject.tag == "P1Goal") || (col.gameObject.tag == "P2Goal")){
            // don't apply because not colliding with paddle
            applyPaddleDirection = false;
        }

        // save who hit the ball
        PaddleUnit paddle = col.gameObject.GetComponent<PaddleUnit>();
        if (paddle.playerID == 1){
            whoLastHit = LastContact.P1;
        }else{
            whoLastHit = LastContact.P2;
        }

        // check tag on paddle
        switch(col.gameObject.tag){
            case "Earth":
                // increase speed
                xSpeed += earthSpeedAddition;
                ySpeed += earthSpeedAddition;
                // reverse x direction
                xDirection *= -1;
                break;
            case "Water":
                if (state == BallStates.WHOLE){
                    // decrease speed (WARNING: this will allow ball to have negative speed)
                    xSpeed -= waterSpeedDeduction;
                    ySpeed -= waterSpeedDeduction;
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    // deduct point from the player that broke it
                    paddle.DeductFromScore();
                    // FIXME: break ball, pause, then respawn it
                }
                // reverse x direction
                xDirection *= -1;
                break;
            case "Air": // a spike
                // removes y movement
                ySpeed = 0.0f;
                yDirection = 0.0f;
                // add  air speed to x speed
                xSpeed += airSpeedAddition;
                // don't apply paddle directiont to keep the straight shot
                applyPaddleDirection = false;
                // reverse x direction
                xDirection *= -1;
                break;
            case "Fire":
                // if whole, change state to cracked
                if (state == BallStates.WHOLE){
                    state = BallStates.CRACKED;
                // if already cracked, change state to broken
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    // deduct point from the player that broke it
                    paddle.DeductFromScore();
                    // FIXME: break ball, pause, then respawn it
                }
                // reverse x direction
                xDirection *= -1;
                break;
            default:
                // do nothing
                break;
        }

        // FIXME: apply paddle movement direction to ball
        if (applyPaddleDirection){
        }
    }

}
