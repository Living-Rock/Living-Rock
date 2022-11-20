using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager instance;

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

        if (!PlayerPrefs.HasKey("spawnPosition_x"))
        {
            PlayerPrefs.SetFloat("spawnPosition_x", transform.position.x);
            PlayerPrefs.SetFloat("spawnPosition_y", transform.position.y);
        }
    }

    private void Start()
    {
        spawnPosition = FindObjectOfType<CharacterController>().transform.position;
    }

    public void RespawnPlayer()
    {
        SceneTransition.Instance.ReloadCurrentScene(spawnPosition);
    }

}
    

