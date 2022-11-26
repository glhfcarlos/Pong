using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElementalPowers : MonoBehaviour
{
    private PlayerInput playerInput;


    /*
        Change sprite
        change speed
        change tag (so ball can access it)
        access to different sprites to change object's
    */

    private SpriteRenderer sp;
    private PaddleUnit paddle;

    // Start is called before the first frame update
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        paddle = GetComponent<PaddleUnit>();
        playerInput = GetComponent<PlayerInput>();
    }

    /*
        move up.
    */
    public void MoveUp(InputAction.CallbackContext context){
        if (context.performed){
            //Debug.Log("u");
            paddle.SetDirection(1.0f);
        }if (context.canceled){
            paddle.ResetCurrentVelocity();
        }
    }

    /*
        move down.
    */
    public void MoveDown(InputAction.CallbackContext context){
        if (context.performed){
            //Debug.Log("d");
            paddle.SetDirection(-1.0f);
        }if (context.canceled){
            paddle.ResetCurrentVelocity();
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to earth.
    */
    public void EquipEarth(InputAction.CallbackContext context){
        if (context.performed){
            //Debug.Log("e");
            // change tag
            gameObject.tag = "Earth";
            // change sprite to earth
            sp.sprite = paddle.elementalSprites[0];
            // FIXME: decrease speed
            paddle.SetCurrentSpeed(paddle.earthSpeed);
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to water.
    */
    public void EquipWater(InputAction.CallbackContext context){
        if (context.performed){
            //Debug.Log("w");
            // change tag
            gameObject.tag = "Water";
            // change sprite to water
            sp.sprite = paddle.elementalSprites[1];
            // FIXME: increase speed
            paddle.SetCurrentSpeed(paddle.waterSpeed);
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to air.
    */
    public void EquipAir(InputAction.CallbackContext context){
        if (context.performed){
            //Debug.Log("a");
            // change tag
            gameObject.tag = "Air";
            // change sprite to air
            sp.sprite = paddle.elementalSprites[2];
            // change speed to default
            paddle.SetCurrentSpeed(paddle.defaultSpeed);
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to fire.
    */
    public void EquipFire(InputAction.CallbackContext context){
        if (context.performed){
            //Debug.Log("f");
            // change tag
            gameObject.tag = "Fire";
            // change sprite to fire
            sp.sprite = paddle.elementalSprites[3];
            // change speed to default
            paddle.SetCurrentSpeed(paddle.defaultSpeed);
        }
    }

    public void PauseGame(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("pausing game");
            playerInput.SwitchCurrentActionMap("UI");
            FindObjectOfType<PauseMenu>().Pause();
        }
    }
}
