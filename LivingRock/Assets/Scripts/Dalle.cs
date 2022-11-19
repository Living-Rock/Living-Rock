using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dalle : MonoBehaviour
{
    [SerializeField] private Sprite spriteDefaut;
    [SerializeField] private Sprite spriteAppuyee;
   
    [SerializeField] private UnityEvent onPressedByPlayer;
    [SerializeField] private UnityEvent onReleasedByPlayer;
    [SerializeField] private UnityEvent onPressedByCrystal;
    [SerializeField] private UnityEvent onReleasedByCrystal;
    [SerializeField] private UnityEvent onPressedByCaisse;
    [SerializeField] private UnityEvent onReleasedByCaisse;


    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteDefaut;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            onPressedByPlayer.Invoke();
            spriteRenderer.sprite = spriteAppuyee;
        }
        else if (collision.tag == "Crystal")
        {
            onPressedByCrystal.Invoke();
            spriteRenderer.sprite = spriteAppuyee;
        }
        else if (collision.tag == "Caisse")
        {
            onPressedByCaisse.Invoke();
            spriteRenderer.sprite = spriteAppuyee;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onReleasedByPlayer.Invoke();
            spriteRenderer.sprite = spriteDefaut;
        }
        else if (collision.tag == "Crystal")
        {
            onReleasedByCrystal.Invoke();
            spriteRenderer.sprite = spriteDefaut;
        }
        else if (collision.tag == "Caisse")
        {
            onReleasedByCaisse.Invoke();
            spriteRenderer.sprite = spriteDefaut;
        }
    }

    public void TestDebug(string hello)
    {
        Debug.Log(hello);
    }
}
