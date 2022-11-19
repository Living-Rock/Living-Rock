using UnityEngine;

public class RespawnManager : MonoBehaviour
{
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

    public void RespawnPlayer()
    {
        SceneTransition.Instance.ReloadCurrentScene();
    }

}
    

