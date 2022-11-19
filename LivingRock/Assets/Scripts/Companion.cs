using UnityEngine;
using UnityEngine.InputSystem;

public class Companion : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float followSpeed;
    public bool followPlayer = true;

    private void Start()
    {
        transform.position = player.position;
        playerInput.actions["CompanionFollow"].performed += _ => followPlayer = !followPlayer;
    }

    private void Update()
    {
        if (followPlayer)
        {
            transform.position =
                Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
            return;
        }
        
        Vector2 move = playerInput.actions["MoveCompanion"].ReadValue<Vector2>();
        transform.position += (Vector3) move * (moveSpeed * Time.deltaTime);
    }
}
