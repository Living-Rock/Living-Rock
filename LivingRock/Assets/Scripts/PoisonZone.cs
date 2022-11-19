using UnityEngine;

public class PoisonZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            RespawnManager.Instance.RespawnPlayer();
    }
}