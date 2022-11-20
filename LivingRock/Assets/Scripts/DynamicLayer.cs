using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLayer : MonoBehaviour
{
    private BoxCollider2D roomScale;

    private float yMin, yMax;

    private void Awake()
    {
        roomScale = GameObject.FindGameObjectWithTag("CameraRoom").GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        yMax = roomScale.bounds.size.y / 2 + roomScale.bounds.center.y + transform.position.y;
        yMin = -roomScale.bounds.size.y / 2 + roomScale.bounds.center.y + transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.01f);
    }
}
