using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trou : MonoBehaviour
{
    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D player = Physics2D.OverlapBox(transform.position, collider.bounds.size * 0.9f, 0);
        if (player != null && player.tag.Equals("Player"))
        {
            RespawnManager.Instance.RespawnPlayer();
        }
    }

}
