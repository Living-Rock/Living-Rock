using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager instance;

    public static RespawnManager Instance {get; private set;}

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);    // Suppression d'une instance pr�c�dente (s�curit�...s�curit�...)
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
    

