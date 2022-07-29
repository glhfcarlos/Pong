
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

        public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
    }

        private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            
        }
        //Air: straight line to the other side
        else if (other.gameObject.CompareTag("Earth"))
        {

        }
        //Earth: Strenght of force is increases
        else if (other.gameObject.CompareTag("Fire"))
        {

        }
        //Fire: Destory Ball and restart
        else if (other.gameObject.CompareTag("Water"))
        {

        }
        //Water: Unsure
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
    }
    public void AddForce(Vector2 force) 
    {
        _rigidbody.AddForce(force);
    }

}
