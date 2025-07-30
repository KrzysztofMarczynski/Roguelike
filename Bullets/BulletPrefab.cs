using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    [Header("Statystyki pocisku")]
    [SerializeField] private GameObject itemOnDestroy;

    [HideInInspector] public Vector2 Direction;
    private Rigidbody2D rb;
    private AudioManager audioManager;
    private Gun gun;
    private Bullet bullet;

    public float boost = 1f;

    void Awake()
    {
        gun = FindAnyObjectByType<Gun>();
        audioManager = FindAnyObjectByType<AudioManager>();
        bullet = FindAnyObjectByType<Bullet>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Direction.normalized * gun.fireSpeed;

        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") ||
            collision.CompareTag("Enemy")||
            collision.CompareTag("Door") ||
            collision.CompareTag("Teleport"))
        {
            Destroy(gameObject);
        }
    }
}
