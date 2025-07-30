using UnityEngine;

public class EnemyDialog : MonoBehaviour, IInteractable
{
    [SerializeField] public TextAsset Diaglog1;
    [SerializeField] public TextAsset Diaglog2;
    [SerializeField] public TextAsset Diaglog3;
    [SerializeField] public TextAsset Diaglog4;
    [SerializeField] GameObject doll;
    [SerializeField] GameObject boost;
    [SerializeField] GameObject sign;

    public int x = 1;

    private DialogBox dialogBox;
    private Tutorial tutorial;
    public bool stoptalk;

    enum caseDialog
    {
        d1 = 0,
        d2 = 1,
        d3 = 2,
        d4 = 3
    }

    caseDialog diag;

    public void SetCaseDialog(int x)
    {
        diag = (caseDialog)x;
    }

    void Awake()
    {
        dialogBox = FindAnyObjectByType<DialogBox>();
        SetCaseDialog(0);
    }

    public void Interact()
    {
        doll.SetActive(true);
        tutorial = FindAnyObjectByType<Tutorial>();
        sign.SetActive(false);

        switch (diag)
        {
            case caseDialog.d1:
                dialogBox.RunDialog(Diaglog1);
                tutorial.PlusHealth(10f);
                break;
            case caseDialog.d2:
                dialogBox.RunDialog(Diaglog2);
                tutorial.PlusHealth(10f);
                boost.SetActive(true);
                break;
            case caseDialog.d3:
                dialogBox.RunDialog(Diaglog3);
                tutorial.PlusHealth(10f);
                break;
            case caseDialog.d4:
                dialogBox.RunDialog(Diaglog4);
                tutorial.PlusHealth(100f);
                break;

        }
    }
    public void ShowSigh()
    {
        sign.SetActive(true);
    }

    // void OnTriggerStay2D(Collider2D collision)
    // {
    //     tutorial.capsuleCollider2D.enabled = false;
    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     tutorial.capsuleCollider2D.enabled = true;
    // }
}

