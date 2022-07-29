using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleUnit : MonoBehaviour
{
    // for the player manager
    public int playerID;
    public Vector3 startPosition;

    public float defaultSpeed; // default vertical movement
    public float earthSpeed; // for earth power
    public float waterSpeed; // for the water power
    public float direction;
    public int score;
    public List<Sprite> elementalSprites;

    private float currentSpeed;
    private Vector3 currentVelocity;
    private Rigidbody2D rb;
    
    // Awake is called
    void Awake()
    {
        transform.position = startPosition;
        direction = 1.0f;
        currentSpeed = defaultSpeed;
        currentVelocity = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        // updates the current velocity
        currentVelocity.y = direction * currentSpeed;
        // applies force
        rb.AddForce(currentVelocity);
        Debug.Log(currentVelocity);
    }

    // resets position
    public void ResetPosition(){
        rb.position = startPosition;
        rb.velocity = Vector3.zero;
    }

    // returns the current speed of the paddle
    public float GetCurrentSpeed(){
        return currentSpeed;
    }
    // sets the current speed of the paddle
    public void SetCurrentSpeed(float speed){
        currentSpeed = speed;
        return;
    }

    // returns the direction of the paddle
    public float GetDirection(){
        return direction;
    }
    // sets the direction of the paddle
    public void SetDirection(float dir){
        direction = dir;
        return;
    }

    /*
        This is setting the direction instead of teh paddle so 
        that when the up/down buttons are released, a zero
        direction will set the y velocity to zero as well.
        When the up/down buttons are held again, the speed remains
        as at the same value as before, but the direction changes to
        -1 or 1, making the paddle move again.
    */
    public void ResetCurrentVelocity(){
        //currentVelocity = Vector2.zero;
        direction = 0;
        return;
    }

    /*
        This is a function so that audio and animation and VFX
        can be played here as well if needed.
    */
    public void AddToScore(){
        score++;
        return;
    }
    /*
        This is a function so that audio and animation and VFX
        can be played here as well if needed.
    */
    public void DeductFromScore(){
        score--;
        return;
    }
}
