using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelected;
    
    public GameObject FirstSelected
    {
        get => firstSelected;
        private set => firstSelected = value;
    }

    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void Show()
    {
        Show(firstSelected);
    }

    public void Show(GameObject selected)
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(selected);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}