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
    private Rigidbody2D rb;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    /*
        move up.
    */
    void MoveUp(InputAction.CallbackContext context){
    }

    /*
        move down.
    */
    void MoveDown(InputAction.CallbackContext context){
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to earth.
    */
    void EquipEarth(InputAction.CallbackContext context){
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to water.
    */
    void EquipWater(InputAction.CallbackContext context){
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to air.
    */
    void EquipAir(InputAction.CallbackContext context){
    }

    /*
        When button is pressed (start) and power isn't already equipped, 
        change power to fire.
    */
    void EquipFire(InputAction.CallbackContext context){
    }
}
