using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private GameObject player;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RespawnPlayer()
    {
        player.transform.position = startPosition;
    }
}
