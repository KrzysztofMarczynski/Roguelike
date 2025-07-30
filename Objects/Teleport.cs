using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Header("Teleport partner")]
    [SerializeField] private Teleporter partner;

    public bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet"))
        {
            if (!canTeleport || partner == null) return;

            partner.canTeleport = false;

            other.transform.position = partner.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet"))
        {
            canTeleport = true;
        }
    }
}
