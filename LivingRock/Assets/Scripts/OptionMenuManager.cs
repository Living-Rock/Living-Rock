using UnityEngine;
using UnityEngine.InputSystem;

public class OptionMenuManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Menu optionMenu;
    [SerializeField] private Menu parentMenu;
    [SerializeField] private GameObject optionButton;
    
    private void OnEnable()
    {
        playerInput.actions["Pause"].performed += Back;
    }

    private void OnDisable()
    {
        playerInput.actions["Pause"].performed -=Back;
    }

    private void Back(InputAction.CallbackContext ctx)
    {
        if (optionMenu.gameObject.activeSelf)
        {
            parentMenu.Show(optionButton);
            optionMenu.Hide();
        }
    }
}
