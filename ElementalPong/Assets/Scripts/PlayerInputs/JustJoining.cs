using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JustJoining : MonoBehaviour
{
    private bool controlSet;

    private PlayerInput playerInput;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controlSet = false;
    }

    /* The below functions are for managing players joining with controller or a keyboard */

    public void FlagKeyboardJoin1(InputAction.CallbackContext context){
        if (context.performed && !controlSet){
            playerInput.SwitchCurrentActionMap("P1");
            controlSet = true;
        }
    }
    public void FlagKeyboardJoin2(InputAction.CallbackContext context){
        if (context.performed && !controlSet){
            playerInput.SwitchCurrentActionMap("P2");
            controlSet = true;
        }
    }
    public void FlagGamepadJoin(InputAction.CallbackContext context){
        if (context.performed && !controlSet){
            playerInput.SwitchCurrentActionMap("Game");
            controlSet = true;
        }
    }
}
