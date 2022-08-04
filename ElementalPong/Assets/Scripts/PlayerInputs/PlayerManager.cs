using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameManager game;

    void OnPlayerJoined(PlayerInput playerInput){
        PaddleUnit paddle = playerInput.gameObject.GetComponent<PaddleUnit>();

        /*
            If player joins with keyboard, give them the P1 action map and set p1IsTaken to true.
            If player joins with gamepad, give them the Game action map.
            If player joins with keyboard and p1IsTaken is true, give them P2 action map.
        */
        /*
        if (paddle.controlInUse == ControlType.GAMEPAD){
            playerInput.SwitchCurrentActionMap("Game");
        }else if (paddle.controlInUse == ControlType.KEYBOARD1){
            playerInput.SwitchCurrentActionMap("P1");
        }else if (paddle.controlInUse == ControlType.KEYBOARD2){
            playerInput.SwitchCurrentActionMap("P2");
        }
        */

        Debug.Log("Player Input ID: " + playerInput.playerIndex.ToString());

        // Set the player ID, add one to the index to start at Player 1
        paddle.playerID = playerInput.playerIndex + 1;
        // Set the start spawn position of the player using the location at the associated element into the array.
        paddle.startPosition = spawnLocations[playerInput.playerIndex].position;

        if (playerInput.playerIndex == 0){
            game.TrackPlayer1(paddle);
        }else if (playerInput.playerIndex == 1){
            game.TrackPlayer2(paddle);
        }
    }
}
