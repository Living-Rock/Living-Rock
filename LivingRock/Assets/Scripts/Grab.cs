using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    private bool isGrabbing;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float grabDistance;

    [SerializeField] private float crystalSpeedFactor;

    [SerializeField] private int maxEnergy;
    private int currentEnergy;

    private float grabDelay = .3f;
    private float timer = 0f;
    private Vector2 baseColliderOffset;
    private Vector2 baseColliderSize;
    private CapsuleCollider2D capsuleCollider;
    private CharacterController characterController;

    public bool IsGrabbing { get { return isGrabbing; }}
    // Start is called before the first frame update
    void Start()
    {
        isGrabbing = false;
        capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        baseColliderOffset = capsuleCollider.offset;
        baseColliderSize = capsuleCollider.size;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Agrippage"].ReadValue<float>() > 0f && Time.time > timer + grabDelay)
        {
            timer = Time.time;
            if (!isGrabbing)
            {
                PickupMovable();
            } else
            {
                DropMovable();
            }
        }
        


    }

    private void PickupMovable()
    {
        isGrabbing = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, grabDistance);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag.Equals("Movable") || collider.tag.Equals("Crystal"))
            {
                if (collider.tag.Equals("Crystal")) gameObject.GetComponent<CharacterController>().SpeedFactor = crystalSpeedFactor;
                collider.gameObject.transform.parent = transform;
                collider.gameObject.GetComponent<Collider2D>().enabled = false;
                correctMovablePosition(collider.transform, collider);
                break;
            }
        }
    }

    public void DropMovable()
    {
        gameObject.GetComponent<CharacterController>().SpeedFactor = 1f;
        isGrabbing = false;
        Collider2D[] colliders = gameObject.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag.Equals("Movable") || collider.tag.Equals("Crystal"))
            {

                collider.gameObject.transform.parent = transform.parent;
                collider.gameObject.GetComponent<Collider2D>().enabled = true;
                capsuleCollider.size = baseColliderSize;
                capsuleCollider.offset = baseColliderOffset;
                characterController.LockSprite(CharacterController.Pos.None);
                break;
            }
        }
    }
    private void correctMovablePosition(Transform movablePos, Collider2D col)
    {
        float x_diff = transform.position.x - movablePos.position.x;
        float y_diff = transform.position.y - movablePos.position.y;

        if (Mathf.Abs(x_diff) < Mathf.Abs(y_diff))
        {
            movablePos.position = new Vector3(transform.position.x, movablePos.position.y);
            capsuleCollider.size = new Vector2(Mathf.Max(baseColliderSize.x, col.bounds.size.x), (baseColliderSize.y+col.bounds.size.y)*2);
            capsuleCollider.offset = new Vector2(0, baseColliderOffset.y - y_diff/ 2);
            characterController.LockSprite(y_diff >= 0 ? CharacterController.Pos.Bas : CharacterController.Pos.Haut);

        } else
        {
            movablePos.position = new Vector3(movablePos.position.x, transform.position.y);
            capsuleCollider.size = new Vector2((baseColliderSize.x + col.bounds.size.x)*2, Mathf.Max(baseColliderSize.y, col.bounds.size.y));
            capsuleCollider.offset = new Vector2(baseColliderOffset.x - x_diff / 2, 0);
            characterController.LockSprite(x_diff >= 0 ? CharacterController.Pos.Gauche : CharacterController.Pos.Droite);
        }

        
    }
}
