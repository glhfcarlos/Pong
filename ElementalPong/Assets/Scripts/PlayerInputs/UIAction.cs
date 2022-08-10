using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIAction : MonoBehaviour
{
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    /*
        scroll upwards through options.
    */
    public void ScrollUp(InputAction.CallbackContext context){
        if (context.canceled){
            Debug.Log("scrolling up");
        }
    }

    /*
        scroll downwards through options.
    */
    public void ScrollDown(InputAction.CallbackContext context){
        if (context.canceled){
            Debug.Log("scrolling down");
        }
    }

    /*
        scroll leftwards through options.
    */
    public void ScrollLeft(InputAction.CallbackContext context){
        if (context.canceled){
            Debug.Log("scrolling left");
        }
    }

    /*
        scroll rightwards through options.
    */
    public void ScrollRight(InputAction.CallbackContext context){
        if (context.canceled){
            Debug.Log("scrolling right");
        }
    }

    /*
        select an option.
    */
    public void SelectOption(InputAction.CallbackContext context){
        if (context.canceled){
            Debug.Log("selecting");
        }
    }

    public void UnPause(InputAction.CallbackContext context){
        if (context.canceled){
            Debug.Log("selecting");
            playerInput.SwitchCurrentActionMap("Game");
            FindObjectOfType<PauseMenu>().Resume();
        }
    }
}
