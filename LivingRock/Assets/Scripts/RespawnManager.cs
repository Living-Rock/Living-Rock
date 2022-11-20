using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager instance;

    public int respawnSceneIndex { get; set; }
    public Vector2 spawnPosition { get; set; }

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

    private void Start()
    {
        respawnSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void RespawnPlayer()
    {
        SceneTransition.Instance.ReloadCurrentScene(respawnSceneIndex, spawnPosition);
    }

}
    

