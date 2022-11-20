using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float velocity;
    public float Velocity { get { return velocity; } set { velocity = value; } }

    private Vector3 direction;

    public Vector3 Direction { get { return direction; } set { direction = value; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * direction* Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("Crystal"))
            RespawnManager.Instance.RespawnPlayer();
        Destroy(gameObject);
    }
    
}
