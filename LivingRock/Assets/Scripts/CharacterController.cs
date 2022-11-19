using System;
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

    private float speedFactor = 1f;
    public float SpeedFactor { get { return speedFactor; } set { speedFactor = value; } }

    [SerializeField] private Sprite[] front;
    [SerializeField] private Sprite[] back;
    [SerializeField] private Sprite[] right;
    [SerializeField] private Sprite[] left;

    [SerializeField] private float animationFrameTime = 0.25f;

    public enum Pos : int {
        None = 0,
        Haut = 1,
        Bas = 2,
        Gauche = 3,
        Droite = 4
    }

    private int lockPos = 0;

    private int currentAnimationStep = 3;

    private SpriteRenderer rend;

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.sprite = front[0];
    }

    private void UpdateVelocity(Vector2 moveVector)
    {
        if (moveVector.sqrMagnitude < deadZone * deadZone)
        {
            float velocityNorm = Mathf.Clamp(velocity.magnitude - (playerSpeed / release) * Time.deltaTime, 0.0001f, playerSpeed);

            velocity = velocityNorm * velocity.normalized;

            currentAnimationStep = 3;

            UpdateSprite(velocity);

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

            velocity = velocity - Vector2.Dot(velocity.normalized, normal)*normal;
            transform.position += (Vector3)(velocity.normalized * hit.distance);
        }
    }

    void Update()
    {
        Vector2 moveVector = playerInput.actions["Move"].ReadValue<Vector2>();

        UpdateSprite(moveVector);

        if (moveVector.sqrMagnitude > 1)
        {
            moveVector = moveVector.normalized;
        }

        UpdateVelocity(moveVector);

        DetectCollision();

        transform.position += (Vector3)(velocity * Time.deltaTime * speedFactor);

        
    }

    private float lastAnimationFrameDate = 0;

    private void UpdateSprite(Vector2 movDir)
    {
        if(lastAnimationFrameDate + animationFrameTime < Time.time)
        {
            currentAnimationStep += 1;
            currentAnimationStep %= front.Length;
            lastAnimationFrameDate = Time.time;
        }

        switch ((Pos)lockPos)
        {
            case Pos.Haut:
                rend.sprite = back[currentAnimationStep];
                break;
            case Pos.Bas:
                rend.sprite = front[currentAnimationStep];
                break;
            case Pos.Droite:
                rend.sprite = right[currentAnimationStep];
                break;
            case Pos.Gauche:
                rend.sprite = left[currentAnimationStep];
                break;
            default:
                float abs_x = Mathf.Abs(movDir.x);
                float abs_y = Mathf.Abs(movDir.y);
                if (abs_x < abs_y)
                {
                    if (movDir.y < 0) rend.sprite = front[currentAnimationStep];
                    else rend.sprite = back[currentAnimationStep];
                }
                else
                {
                    if (movDir.x < 0) rend.sprite = left[currentAnimationStep];
                    else rend.sprite = right[currentAnimationStep];
                }
                break;
        }

        
    }

    public void LockSprite(Pos pos)
    {
        lockPos = (int)pos;
    }
}


/*RaycastHit2D closest_hit;
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