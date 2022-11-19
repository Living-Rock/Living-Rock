using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour
{
    private RespawnManager respawnManager;
    // Start is called before the first frame update
    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            respawnManager.RespawnPlayer();
        }
    }
}
