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
}