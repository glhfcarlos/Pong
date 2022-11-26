using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIManager : MonoBehaviour
{
    public GameObject ai;

    private PlayerManager manager;

    // Start is called before the first frame update
    void Start()
    {
        // FIXME: change max player count to 1

        // Allow Game Manager to track AI
        manager = GetComponent<PlayerManager>();
        PaddleUnit paddle = ai.GetComponent<PaddleUnit>();
        manager.game.TrackPlayer2(paddle);
    }
}
