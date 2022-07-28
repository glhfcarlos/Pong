using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public Transform target;

    public float movementSpeed;
    
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Called();
    }
    private void Called()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 newPosition = target.position;

        newPosition = newPosition + (-target.forward * offset.z);
        newPosition.y += offset.y;

        transform.position = Vector3.MoveTowards(transform.position, newPosition,
            movementSpeed * Time.deltaTime);


        }
    }
}
