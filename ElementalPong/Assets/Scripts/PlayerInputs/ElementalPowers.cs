using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElementalPowers : MonoBehaviour
{
    /*
        Change sprite
        change speed (rigidbody)
        change tag (so ball can access it)
        access to different sprites to change object's
    */
    private SpriteRenderer sp;
    private Unit paddle;

    // Start is called before the first frame update
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        paddle = GetComponent<Unit>();
    }

    /*
        move up.
    */
    public void MoveUp(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("u");
        }
    }

    /*
        move down.
    */
    public void MoveDown(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("d");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to earth.
    */
    public void EquipEarth(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("e");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to water.
    */
    public void EquipWater(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("w");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to air.
    */
    public void EquipAir(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("a");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to fire.
    */
    public void EquipFire(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("f");
        }
    }
}
