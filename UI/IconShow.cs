using UnityEngine;
using UnityEngine.UI;

public class IconShow : MonoBehaviour
{
    public Image imagetest;
    private EnemyDialog enemyDialog;

    [SerializeField] Sprite KKK;
    [SerializeField] Sprite Sign;

    void Awake()
    {
        imagetest = GetComponent<Image>();
        enemyDialog = FindAnyObjectByType<EnemyDialog>();
    }

    public void SetIcon(Sprite icon)
    {
        imagetest.sprite = icon;
    }
}
