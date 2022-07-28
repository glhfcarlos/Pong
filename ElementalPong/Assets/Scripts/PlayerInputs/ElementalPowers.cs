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
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        paddle = GetComponent<Unit>();
    }

    /*
        move up.
    */
    void MoveUp(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("u");
        }
    }

    /*
        move down.
    */
    void MoveDown(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("d");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to earth.
    */
    void EquipEarth(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("e");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to water.
    */
    void EquipWater(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("w");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to air.
    */
    void EquipAir(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("a");
        }
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to fire.
    */
    void EquipFire(InputAction.CallbackContext context){
        if (context.performed){
            Debug.Log("f");
        }
    }
}
