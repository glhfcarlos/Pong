using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public Transform player1Location;
    public Transform player2Location;

    private PlayerInputManager manager;

    // Start is called before the first frame update
    void Awake()
    {
        manager = GetComponent<PlayerInputManager>();    
    }

    /*
        When the first player joins, spawn them on the left side,
        when the second player joins, spawn them on the right
        side.
    */
    void HandlePlayerJoin(){
        Debug.Log(manager.playerCount);
    }
    /*
        When a player leaves, pause game.
    */
}
