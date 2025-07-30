using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Player Health")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private float damageAnimTime = 0.2f;
    private UIManager uIManager;
    private AudioManager audioManager;


    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        uIManager = FindAnyObjectByType<UIManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float amount)
    {
        playerStats.health -= amount;
        StartCoroutine(DamageAnimation());

        uIManager.FlashHealthbar(damageAnimTime);
        audioManager.PlaySFX(audioManager.death);

        if (playerStats.health <= 0f)
        {
            Die();
        }
    }

    private System.Collections.IEnumerator DamageAnimation()
    {
        playerMovement.animator.SetBool(playerMovement.DMGTake, true);
        yield return new WaitForSeconds(damageAnimTime);
        playerMovement.animator.SetBool(playerMovement.DMGTake, false);
    }

    private void Die()
    {
        Debug.Log("Player has died.");
    }
}


