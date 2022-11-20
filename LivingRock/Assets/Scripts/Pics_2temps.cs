using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pics_2temps : MonoBehaviour
{

    private SpriteRenderer renderer;
    private BoxCollider2D _collider;
    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        open = false;
        _collider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, _collider.bounds.extents * 0.95f, 0);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag.Equals("Player") || collider.tag.Equals("Crystal"))
                {
                    RespawnManager.Instance.RespawnPlayer();
                    break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            open = true;
            renderer.color = Color.black;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && open)
        {
            RespawnManager.Instance.RespawnPlayer();
        }
    }
}
