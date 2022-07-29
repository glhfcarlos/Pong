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
    public float waterSpeed;
    // the amount to subtract when collide with earth paddle
    public float earthSpeed;
    // the amount to add in the x-direction when collide with air paddle
    public float airSpeed;

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

    }

    void OnCollisionEnter2D(Collision2D col){
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
                break;
            case "Water":
                break;
            case "Air":
                // removes y movement, but keeps x movement
                currentVelocity *= new Vector2(1.0f, 0.0f);
                break;
            case "Fire":
                // if whole, change state to cracked
                if (state == BallStates.WHOLE){
                    state = BallStates.CRACKED;
                // if already cracked, change state to broken
                }else if (state == BallStates.CRACKED){
                    state = BallStates.BROKEN;
                    // deduct point from the player that broke it
                    paddle.score--;
                    // FIXME: break ball, pause, then respawn it
                }
                break;
            default:
                // do nothing
                break;
        }

        // FIXME: reverse x direction
        xDirection += -1;
    }

}
