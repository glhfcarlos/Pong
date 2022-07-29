using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameManager game;

    void OnPlayerJoined(PlayerInput playerInput){
        Debug.Log("Player Input ID: " + playerInput.playerIndex.ToString());

        // Set the player ID, add one to the index to start at Player 1
        playerInput.gameObject.GetComponent<PaddleUnit>().playerID = playerInput.playerIndex + 1;
        // Set the start spawn position of the player using the location at the associated element into the array.
        playerInput.gameObject.GetComponent<PaddleUnit>().startPosition = spawnLocations[playerInput.playerIndex].position;

        if (playerInput.playerIndex == 0){
            game.TrackPlayer1(playerInput.gameObject.GetComponent<PaddleUnit>());
        }else if (playerInput.playerIndex == 1){
            game.TrackPlayer2(playerInput.gameObject.GetComponent<PaddleUnit>());
        }
    }
}
