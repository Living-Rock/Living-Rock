using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Menu pauseMenu;
    [SerializeField] private Menu optionMenu;
    [SerializeField] private GameObject optionButton;
    
    private void OnEnable()
    {
        playerInput.actions["Pause"].performed += SetPause;
    }

    private void OnDisable()
    {
        playerInput.actions["Pause"].performed -= SetPause;
    }

    public void SetPause(InputAction.CallbackContext ctx)
    {
        if (optionMenu.gameObject.activeSelf)
        {
            pauseMenu.Show(optionButton);
            optionMenu.Hide();
        }
        else
        {
            if (!pauseMenu.gameObject.activeSelf)
            {
                pauseMenu.Show();
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.Hide();
                Time.timeScale = 1;
            }
        }
    }

    public void ForceResetTimeScale()
    {
        Time.timeScale = 1;
    }
}
