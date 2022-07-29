using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float movementSpeed; // vertical movement only
    public float speedChange; // for earth and water power
    public int score;
    public List<Sprite> elementalSprites;

    private float currentSpeed;
    
    // Awake is called
    void Awake()
    {
        currentSpeed = movementSpeed;
    }

    // Returns the current speed of the paddle
    public float GetCurrentSpeed(){
        return currentSpeed;
    }

    // adds a float to the current speed of the paddle
    // to decrease speed, add a negative value
    public void SetCurrentSpeed(float change){
        currentSpeed += change;
        return;
    }
}
