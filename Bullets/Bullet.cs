using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Gun gun;
    private BulletPrefab bulletPrefab;

    [SerializeField] private float fireDMG;
    [SerializeField] private float fireRate;
    [SerializeField] public float fireSpeed;
    [SerializeField] private GameObject boost;

    private Animator animator;
    private AudioManager audioManager;

    void Awake()
    {
        gun = FindAnyObjectByType<Gun>();
        animator = GetComponent<Animator>();
        bulletPrefab = FindAnyObjectByType<BulletPrefab>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.CardTake);
            gun.fireDMG = fireDMG;
            gun.fireRate = fireRate;
            gun.fireSpeed = fireSpeed;
            gun.bulletPrefab = bullet;
            animator.SetTrigger("Play");
            boost.SetActive(false);
            Destroy(gameObject, 0.3f);
        }
    }
}
