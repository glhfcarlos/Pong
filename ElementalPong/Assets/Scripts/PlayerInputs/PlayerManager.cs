using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public Transform[] spawnLocations;

    void OnPlayerJoined(PlayerInput playerInput){
        Debug.Log("Player Input ID: " + playerInput.playerIndex.ToString());

        // Set the player ID, add one to the index to start at Player 1
        playerInput.gameObject.GetComponent<Unit>().playerID = playerInput.playerIndex + 1;
        // Set the start spawn position of the player using the location at the associated element into the array.
        playerInput.gameObject.GetComponent<Unit>().startPosition = spawnLocations[playerInput.playerIndex].position;
    }
}
