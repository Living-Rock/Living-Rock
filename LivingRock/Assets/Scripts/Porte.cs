using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{

    [SerializeField] private bool _opened = false;
    public bool opened
    {
        get
        {
            return _opened;
        }
        set
        {
            _opened = value;
            UpdateState();
        }
    }

    [SerializeField] private Sprite openedDoorSprite;
    [SerializeField] private Sprite closedDoorSprite;

    private Collider2D doorCollider;
    private SpriteRenderer spriteRenderer;

    private AudioSource porteSound;


    private void Awake()
    {
        doorCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        porteSound = GameObject.Find("OpenDoorSound").GetComponent<AudioSource>();

        UpdateState();
    }

    

    private void UpdateState()
    {
        if (_opened)
        {
            doorCollider.enabled = false;
            spriteRenderer.sprite = openedDoorSprite;
            porteSound.Play();
        }
        else
        {
            doorCollider.enabled = true;
            spriteRenderer.sprite = closedDoorSprite;
        }

    }
}
