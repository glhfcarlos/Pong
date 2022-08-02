using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleUnit : MonoBehaviour
{
    // for the player manager
    public int playerID;
    public Vector3 startPosition;
    
    public int score;

    public float defaultSpeed; // default vertical movement
    public float earthSpeed; // for earth power
    public float waterSpeed; // for the water power
    public float direction;
    public List<Sprite> elementalSprites;

    private float currentSpeed;
    private Vector3 currentVelocity;

    private PlayerInput playerInput;
    
    // Awake is called
    void Awake()
    {
        transform.position = startPosition;
        direction = 1.0f;
        currentSpeed = defaultSpeed;
        currentVelocity = Vector3.zero;
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate(){
        // updates the current velocity
        currentVelocity.y = direction * currentSpeed * Time.deltaTime;
        // added movement to paddle
        gameObject.transform.position += currentVelocity;
        //Debug.Log(currentVelocity);
    }

    // collision
    void OnCollisionEnter2D(Collision2D other){
        float deflectionOffset = 1.0f;
        Vector3 newPosition = new Vector3(gameObject.transform.position.x,
                                            gameObject.transform.position.y,
                                            gameObject.transform.position.z);

        // if paddle hits top wall, place it just below wall
        if (other.gameObject.tag == "TopWall"){
            newPosition.y = other.gameObject.transform.position.y - other.gameObject.transform.localScale.y - deflectionOffset;
        }

        // if paddle hits bottom wall, place it just below wall
        if (other.gameObject.tag == "BottomWall"){
            newPosition.y = other.gameObject.transform.position.y + other.gameObject.transform.localScale.y + deflectionOffset;
        }

        gameObject.transform.position = newPosition;
    }

    // resets position
    public void ResetPosition(){
        gameObject.transform.position = startPosition;
        ResetCurrentVelocity();
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

    /*
        To switch input maps
    */
    public void ChangeInputMap(string toMap){
        playerInput.SwitchCurrentActionMap(toMap);
    }
}
