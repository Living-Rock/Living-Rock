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
    [SerializeField] private float deadZone = 0.1f;

    private Vector2 velocity = Vector2.zero;


    private void UpdateVelocity(Vector2 moveVector)
    {
        if (moveVector.sqrMagnitude < deadZone * deadZone)
        {
            float velocityNorm = Mathf.Clamp(velocity.magnitude - (playerSpeed / release) * Time.deltaTime, 0.0f, playerSpeed);

            velocity = velocityNorm * velocity.normalized;

            return;
        }
       
        velocity += moveVector * Time.deltaTime * (playerSpeed / attack);

        if (velocity.sqrMagnitude > playerSpeed * playerSpeed)
        {
                velocity = velocity.normalized * playerSpeed;
        }
    }

    void Update()
    {
        //SIMPLE MOVE

        Vector2 moveVector = playerInput.actions["Move"].ReadValue<Vector2>();


        if(moveVector.sqrMagnitude > 1)
        {
            moveVector = moveVector.normalized;
        }


        UpdateVelocity(moveVector);

        

        transform.position += (Vector3)(velocity * Time.deltaTime);
    }
}
