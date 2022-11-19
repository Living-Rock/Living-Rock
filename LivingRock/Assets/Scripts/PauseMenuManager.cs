using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Menu pauseMenu;
    
    private void Awake()
    {
        playerInput.actions["Pause"].performed += _ => SetPause();
    }

    public void SetPause()
    {
        if (!pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(pauseMenu.FirstSelected);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ForceResetTimeScale()
    {
        Time.timeScale = 1;
    }
}
