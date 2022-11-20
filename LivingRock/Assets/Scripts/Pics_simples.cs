using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pics_simples : MonoBehaviour
{
    private BoxCollider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
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

