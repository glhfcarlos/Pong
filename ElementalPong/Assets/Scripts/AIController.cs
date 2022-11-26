using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private SpriteRenderer sp;
    private PaddleUnit paddle;

    // Start is called before the first frame update
    void Awake()
    {
        // tell game that there should be a max of 1 player instead of 2
        sp = GetComponent<SpriteRenderer>();
        paddle = GetComponent<PaddleUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Move up
    public void MoveUp()
    {
        paddle.SetDirection(1.0f);
    }

    // Move down
    public void MoveDown()
    {
        paddle.SetDirection(-1.0f);
    }

    // Uses earth power
    public void UseEarth()
    {
        // change tag
        gameObject.tag = "Earth";
        // change sprite to earth
        sp.sprite = paddle.elementalSprites[0];
        // FIXME: decrease speed
        paddle.SetCurrentSpeed(paddle.earthSpeed);
    }

    // Use water power
    public void UseWater()
    {
        // change tag
        gameObject.tag = "Water";
        // change sprite to water
        sp.sprite = paddle.elementalSprites[1];
        // FIXME: increase speed
        paddle.SetCurrentSpeed(paddle.waterSpeed);
    }

    // Use air power
    public void UseAir()
    {
        // change tag
        gameObject.tag = "Air";
        // change sprite to air
        sp.sprite = paddle.elementalSprites[2];
        // change speed to default
        paddle.SetCurrentSpeed(paddle.defaultSpeed);
    }

    // Use fire power
    public void EquipFire()
    {
        // change tag
        gameObject.tag = "Fire";
        // change sprite to fire
        sp.sprite = paddle.elementalSprites[3];
        // change speed to default
        paddle.SetCurrentSpeed(paddle.defaultSpeed);
    }
}
