using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Animator fader;
    [SerializeField] private int mainMenuBuildIndex;
    [SerializeField] private bool fadeOutOnStart = true;
    [SerializeField] private bool fadeInOnSceneTransition = true;
    
    public static SceneTransition Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)
        else
            Instance = this;
    }

    private void Start()
    {
        if (fadeOutOnStart)
        {
            fader.gameObject.SetActive(true);
            fader.SetTrigger("FadeOut");
        }
    }

    public void LoadScene(int buildIndex)
    {
        if (fadeInOnSceneTransition)
        {
            fader.gameObject.SetActive(true);
            Debug.Log(fader.gameObject.activeSelf);
            fader.SetTrigger("FadeIn");
        }

        SceneManager.LoadScene(buildIndex);
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        LoadScene(mainMenuBuildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
