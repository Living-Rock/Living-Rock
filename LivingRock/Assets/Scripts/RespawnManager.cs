using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private GameObject player;
    private Transform startPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        startPosition = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        player.transform.position = startPosition.position;
        player.transform.rotation = startPosition.rotation; 
    }
}
