using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float attack = 0.1f;
    [SerializeField] private float release = 0.5f;

    private Vector2 velocity;

    void Update()
    {
        //SIMPLE MOVE

        Vector2 moveVector = playerInput.actions["Move"].ReadValue<Vector2>();

        transform.position += (Vector3)(moveVector * playerSpeed * Time.deltaTime);
    }
}
