using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float movementSpeed; // vertical movement only
    public int score;
    public List<Sprite> elementalSprites;
    
    // Awake is called
    void Awake()
    {
        //elementalSprites = new List<Sprite>();
    }
}
