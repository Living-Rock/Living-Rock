using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    private GameObject player;
    private Vector3 startPosition;
    private int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(currentScene);
    }
}
