using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chekpoint : MonoBehaviour
{
    private Collider2D col;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        player = FindObjectOfType<CharacterController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (col.bounds.Contains(player.transform.position))
        {
            RespawnManager.Instance.respawnSceneIndex = SceneManager.GetActiveScene().buildIndex;
            RespawnManager.Instance.spawnPosition = transform.position;
            Debug.Log("kwin");
        }
    }

}
