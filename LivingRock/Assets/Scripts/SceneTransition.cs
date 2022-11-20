using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Animator fader;
    [SerializeField] private int mainMenuBuildIndex;
    [SerializeField] private bool fadeOutOnStart = true;
    [SerializeField] private bool fadeInOnSceneTransition = true;
    [SerializeField] private float fadeInDuration = 1f;

    private CharacterController playerController;

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
        playerController = FindObjectOfType<CharacterController>();
        if (fadeOutOnStart)
            fader.SetTrigger("FadeOut");
    }

    public void LoadScene(int buildIndex)
    {
        StartCoroutine(TransitionCo(buildIndex));
        
    }

    private IEnumerator TransitionCo(int buildIndex)
    {
        playerController.enabled = false;
        if (fadeInOnSceneTransition)
        {
            fader.SetTrigger("FadeIn");
            yield return new WaitForSeconds(fadeInDuration);
        }

        SceneManager.LoadScene(buildIndex);
        playerController.enabled = true;
        yield return null;
    }
    
    public void LoadNextScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadCurrentScene(int index, Vector2 position)
    {
        LoadScene(index);
        playerController.gameObject.transform.position = (Vector3)position;
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
