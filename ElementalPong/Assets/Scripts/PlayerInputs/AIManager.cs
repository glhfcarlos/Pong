using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameManager game;
    public GameObject ai;

    // Start is called before the first frame update
    void Start()
    {
        PaddleUnit paddle = ai.GetComponent<PaddleUnit>();
        game.TrackPlayer2(paddle);
    }
}
