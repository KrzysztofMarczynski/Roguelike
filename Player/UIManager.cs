using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private UnityEngine.UI.Image healthBar;

    [SerializeField] private Color flashColor = Color.red;

    private Color originalColor;

    private void Awake()
    {
        originalColor = healthBar.color;
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,
            playerStats.health / playerStats.maxHealth, Time.deltaTime * 10f);
    }

    public void FlashHealthbar(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine(duration));
    }

    private System.Collections.IEnumerator FlashRoutine(float duration)
    {
        healthBar.color = flashColor;
        yield return new WaitForSeconds(duration);
        healthBar.color = originalColor;
    }

}
