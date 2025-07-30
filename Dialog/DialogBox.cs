using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [Header("Komponenty UI")]
    [SerializeField] private Text textComponent;
    [SerializeField] private GameObject dialogBox;

    [Header("Ustawienia")]
    [SerializeField] private float textSpeed = 0.05f;

    [SerializeField] GameObject img;

    private string[] lines;
    private int index;

    private PlayerMovement playerMovement;
    private Gun gun;
    private EnemyDialog enemyDialog;
    private IconShow iconShow;

    void Awake()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        gun = FindAnyObjectByType<Gun>();
        enemyDialog = FindAnyObjectByType<EnemyDialog>();
        iconShow = FindAnyObjectByType<IconShow>();
    }

    public void RunDialog(TextAsset dialog)
    {
        if (dialogBox.activeSelf)
        {
            if (textComponent.text == lines[index])
                NextLine();
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        else
        {
            playerMovement.canMove = false;
            playerMovement.StopMovement();
            LoadLinesFromFile(dialog);
            index = 0;
            dialogBox.SetActive(true);
            gun.StopShooting();
            StartCoroutine(TypeLine());
        }
    }

    private void LoadLinesFromFile(TextAsset dg)
    {
        if (dg != null)
        {
            lines = dg.text
                .Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Trim();
        }
        else
        {
            Debug.LogWarning("Brak przypisanego pliku dialogowego!");
            lines = new[] { "Brak dialogu." };
        }
    }

    private IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogBox.SetActive(false);
            gun.StartShooting();
            playerMovement.canMove = true;
        }
    }
}
