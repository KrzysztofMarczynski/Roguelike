using UnityEngine;

public class teleport : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject teleportIn;
    [SerializeField] private GameObject teleportOut;
    [SerializeField] private GameObject player;

    public void Interact()
    {
        Debug.Log("Teleporting...");

        TeleportIn(player);
    }

    private void TeleportIn(GameObject obj)
    {
        obj.transform.position = teleportIn.transform.position;
    }

    private void TeleportOut(GameObject obj)
    {
        obj.transform.position = teleportOut.transform.position;
    }
}
