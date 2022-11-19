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
    private AudioSource dalleSound;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteDefaut;
        dalleSound = GameObject.Find("DalleSound").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Player"){
            onPressedByPlayer.Invoke();
            if(onPressedByPlayer.GetPersistentEventCount() > 0)
            {
                spriteRenderer.sprite = spriteAppuyee;
                //dalleSound.Play();
            }    
        }
        if (collision.tag == "Crystal")
        {
            onPressedByCrystal.Invoke();
            if (onPressedByCrystal.GetPersistentEventCount() > 0)
            {
                spriteRenderer.sprite = spriteAppuyee;
                //dalleSound.Play();
            }
        }
        if (collision.tag == "Movable")
        {
            Debug.Log("test");
            onPressedByCaisse.Invoke();
            if (onPressedByCaisse.GetPersistentEventCount() > 0)
            {
                spriteRenderer.sprite = spriteAppuyee;
                //dalleSound.Play();
            }             
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onReleasedByPlayer.Invoke();
            if (onReleasedByPlayer.GetPersistentEventCount() > 0)
            {
                spriteRenderer.sprite = spriteDefaut;
            }
        }
        if (collision.tag == "Crystal")
        {
            onReleasedByCrystal.Invoke();
            if (onReleasedByCrystal.GetPersistentEventCount() > 0)
            {
                spriteRenderer.sprite = spriteDefaut;
            }
        }
        if (collision.tag == "Movable")
        {
            onReleasedByCaisse.Invoke();
            if (onReleasedByCaisse.GetPersistentEventCount() > 0)
            {
                spriteRenderer.sprite = spriteDefaut;
            }
        }
    }

    public void TestDebug(string hello)
    {
        Debug.Log(hello);
    }
}
