using UnityEngine;
using UnityEngine.InputSystem;

public class OptionMenuManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Menu optionMenu;
    [SerializeField] private Menu parentMenu;
    [SerializeField] private GameObject optionButton;
    
    private void Awake()
    {
        playerInput.actions["Pause"].performed += _ => Back();
    }

    private void Back()
    {
        if (optionMenu.gameObject.activeSelf)
        {
            parentMenu.Show(optionButton);
            optionMenu.Hide();
        }
    }
}
