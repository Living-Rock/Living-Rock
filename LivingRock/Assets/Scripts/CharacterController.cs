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
    private CapsuleCollider2D capsuleCollider2D;
    [SerializeField] private ContactFilter2D contactFilter2D;

    [SerializeField] private Sprite front;
    [SerializeField] private Sprite back;
    [SerializeField] private Sprite right;
    [SerializeField] private Sprite left;

    private SpriteRenderer rend;

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.sprite = front;
    }

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

    private void DetectCollision()
    {
        List<RaycastHit2D> results = new List<RaycastHit2D>();

        
        int count = capsuleCollider2D.Cast(velocity, contactFilter2D, results, (velocity*Time.deltaTime).magnitude, true);

        if (count == 0) return;

        

        foreach (RaycastHit2D hit in results)
        { 
            Vector2 normal = hit.normal;

            //Projection orthonormale sur la tangente du plan de collision
            velocity = velocity - Vector2.Dot(velocity.normalized, normal)*normal;
            transform.position += (Vector3)(velocity.normalized * hit.distance);
        }


    }

    void Update()
    {
        Vector2 moveVector = playerInput.actions["Move"].ReadValue<Vector2>();



        if(moveVector.sqrMagnitude > 1)
        {
            moveVector = moveVector.normalized;
        }


        UpdateVelocity(moveVector);

        DetectCollision();

        transform.position += (Vector3)(velocity * Time.deltaTime);

        UpdateSprite(moveVector);
    }

    private void UpdateSprite(Vector2 movDir)
    {
        float abs_x = Mathf.Abs(movDir.x);
        float abs_y = Mathf.Abs(movDir.y);  
        if (abs_x < abs_y)
        {
            if (movDir.y < 0) rend.sprite = front;
            else rend.sprite = back;
        } else
        {
            if (movDir.x < 0) rend.sprite = left;
            else rend.sprite = right;
        }
    }
}



/*      RaycastHit2D closest_hit;
        float closest_dist = Mathf.Infinity;

        foreach(RaycastHit2D hit in results)
        {
            float dist = hit.distance;
            if (dist < closest_dist)
            {
                closest_hit = hit;
                closest_dist = dist;
            }
            
        }*/