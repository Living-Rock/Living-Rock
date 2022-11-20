using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoarseGround : MonoBehaviour
{
    private Collider2D collider;
    private Vector3 extnts;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
        extnts = collider.bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, extnts * 1.1f, 0);
        foreach (Collider2D collider2d in colliders)
        {
            if (collider2d.CompareTag("Player"))
            {
                Grab g = collider2d.gameObject.GetComponent<Grab>();
                if (g.IsGrabbing) g.DropMovable();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Grab g = collision.gameObject.GetComponent<Grab>();
            if (g.IsGrabbing)
            {
                float dx = transform.position.x - collision.transform.position.x;
                float dy = transform.position.y - collision.transform.position.y;
                if (Mathf.Abs(dx) < Mathf.Abs(dy))
                {
                    float dir = dy / Mathf.Abs(dy);
                    collision.transform.position += dir * Vector3.down * .2f;
                } else
                {
                    float dir = dx / Mathf.Abs(dx);
                    collision.transform.position += dir * Vector3.left * .2f;
                }
                g.DropMovable();
            }
        }
    }

}
