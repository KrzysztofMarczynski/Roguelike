using UnityEngine;

public class ShootingZone : MonoBehaviour
{
    private Gun gun;

    void Awake()
    {
        gun = FindAnyObjectByType<Gun>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gun.StopShooting();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gun.StartShooting();
        }
    }
}
