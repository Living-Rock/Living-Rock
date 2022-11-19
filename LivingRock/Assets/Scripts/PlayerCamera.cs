using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private BoxCollider2D roomSpace;
    [SerializeField] private float zoom = 10.0f;

    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
    }


    void Update()
    {
        playerCamera.transform.position = playerTarget.position + zoom * Vector3.back;

        Vector2 bottomLeft = (Vector2)roomSpace.transform.position - roomSpace.size/2 + roomSpace.offset;
        Vector2 topRight = (Vector2)roomSpace.transform.position + roomSpace.size / 2 + roomSpace.offset;

        Vector2 bottomLeftVP = playerCamera.WorldToViewportPoint(bottomLeft);
        Vector2 topRightVP = playerCamera.WorldToViewportPoint(topRight);

        Vector2 cameraSize = playerCamera.ViewportToWorldPoint(Vector2.one) - playerCamera.ViewportToWorldPoint(Vector2.zero);

        if (bottomLeftVP.x > 0)
        {
            playerCamera.transform.position = new Vector3(bottomLeft.x + cameraSize.x/2, playerCamera.transform.position.y, playerCamera.transform.position.z);
        }
        else if (topRightVP.x < 1)
        {
            playerCamera.transform.position = new Vector3(topRight.x - cameraSize.x / 2, playerCamera.transform.position.y, playerCamera.transform.position.z);
        }

        if (bottomLeftVP.y > 0)
        {
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, bottomLeft.y + cameraSize.y / 2, playerCamera.transform.position.z);
        }
        else if (topRightVP.y < 1)
        {
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, topRight.y - cameraSize.y / 2, playerCamera.transform.position.z);
        }

    }
}
