using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] public float health;

    [Header("IteamDrop")]
    [SerializeField] GameObject iteam1;
    [SerializeField] GameObject iteam2;
    [SerializeField] GameObject iteam3;
    [SerializeField] GameObject iteam4;
    [SerializeField] GameObject iteam5;

    private bool droped = true;
    private AudioManager audioManager;
    private EnemyMovement enemyMovement;
    private Gun gun;
    private CapsuleCollider2D capsuleCollider2D;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        enemyMovement = FindAnyObjectByType<EnemyMovement>();
        gun = FindAnyObjectByType<Gun>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDMG();
            audioManager.PlaySFX(audioManager.death);
        }
    }

    public void TakeDMG()
    {
        health -= gun.fireDMG;
        if (health <= 0)
        {
            capsuleCollider2D.enabled = false;
            if (droped == true)
            {
                enemyMovement.DeathAnim();
                audioManager.PlaySFX(audioManager.enemyDied);
                DropIteam(iteam1);
                droped = false;
            }
        }
    }

    public void DropIteam(GameObject iteam)
    {
        Instantiate(iteam, transform.position, transform.rotation);
    }


}
