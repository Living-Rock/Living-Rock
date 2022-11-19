using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pics_simples : MonoBehaviour
{
    private RespawnManager respawnManager;
    private SpriteRenderer renderer;
    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
        renderer = GetComponent<SpriteRenderer>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("coin");
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
            respawnManager.RespawnPlayer();
        }
    }
}
