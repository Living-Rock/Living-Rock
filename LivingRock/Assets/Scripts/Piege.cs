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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            respawnManager.RespawnPlayer();
        }
    }
}
