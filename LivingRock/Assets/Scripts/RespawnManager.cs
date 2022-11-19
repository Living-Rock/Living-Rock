using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    private int currentScene;

    private static RespawnManager instance;

    public static RespawnManager Instance {get; private set;}

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    public void Update()
    {
    }

    public void RespawnPlayer()
    {
        SceneManager.LoadSceneAsync(currentScene);
    }

}
    

