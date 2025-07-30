using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Prefaby i punkt wystrzału")]
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Parametry ognia")]
    [SerializeField] public float fireRate;
    [SerializeField] public float fireSpeed;
    [SerializeField] public float fireDMG;
    private float fireCooldown;
    private AudioManager audioManager;

    public bool canShot = true;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Update()
    {
        if (canShot == true)
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.RightArrow)) dir = Vector2.right;
            else if (Input.GetKey(KeyCode.LeftArrow)) dir = Vector2.left;
            else if (Input.GetKey(KeyCode.UpArrow)) dir = Vector2.up;
            else if (Input.GetKey(KeyCode.DownArrow)) dir = Vector2.down;

            if (fireCooldown > 0f)
                fireCooldown -= Time.deltaTime;

            if (dir != Vector2.zero && fireCooldown <= 0f)
            {
                Shoot(dir);
                fireCooldown = 1f / fireRate;
            }
        }
    }

    private void Shoot(Vector2 direction)
    {
        audioManager.PlaySFX(audioManager.bulletFire);
        var b = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        b.GetComponent<BulletPrefab>().Direction = direction;
    }

    public void StopShooting()
    {
        canShot = false;
    }

    public void StartShooting()
    {
        canShot = true;
    }
}
