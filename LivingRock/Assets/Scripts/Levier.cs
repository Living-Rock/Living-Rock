using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Levier : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Sprite spriteOff;
    [SerializeField] private Sprite spriteOn;

    [SerializeField] private bool enabled = false;
   
    [SerializeField] private UnityEvent onPressedByPlayer;
    [SerializeField] private UnityEvent onReleasedByPlayer;


    private SpriteRenderer spriteRenderer;
    private Collider2D rangeCollider;
    private GameObject player;

    private void Awake()
    {
        rangeCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteOff;
        player = GameObject.FindGameObjectWithTag("Player");

        playerInput.actions["Interaction"].performed += _ => OnInteract();
    }

    public void OnInteract()
    {
        if (rangeCollider.bounds.Contains(player.transform.position))
        {
            enabled = !enabled;
            if (enabled)
            {
                spriteRenderer.sprite = spriteOn;
                onPressedByPlayer.Invoke();
            }
            else
            {
                spriteRenderer.sprite = spriteOff;
                onReleasedByPlayer.Invoke();
            }
        }
    }

    public void TestDebug(string hello)
    {
        Debug.Log(hello);
    }
}
