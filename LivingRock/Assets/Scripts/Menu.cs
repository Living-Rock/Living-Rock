using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelected;

    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }
}