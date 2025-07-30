using UnityEngine;

public class Sign : MonoBehaviour, IInteractable
{
    private DialogBox dialogBox;
    private Key key;
    private Dialogs dialogs;

    void Awake()
    {
        dialogBox = FindAnyObjectByType<DialogBox>();
        key = FindAnyObjectByType<Key>();
        dialogs = FindAnyObjectByType<Dialogs>();
    }
    public void Interact()
    {
        if (key.key == false)
        {
            dialogBox.RunDialog(dialogs.dialog1);
        }
        else if (key.key == true)
        {
            dialogBox.RunDialog(dialogs.dialog2);
        }
    }
}
