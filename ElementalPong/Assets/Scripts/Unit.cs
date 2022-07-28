using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float movementSpeed;
    public int score;
    public List<Sprite> elementalSprites;
    // Start is called before the first frame update
    void Awake()
    {
        elementalSprites = new List<Sprite>();
    }
}
