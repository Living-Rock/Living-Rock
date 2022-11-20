using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chekpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetFloat("spawnPosition_x", transform.position.x);
        PlayerPrefs.SetFloat("spawnPosition_y", transform.position.y);
    }

}
