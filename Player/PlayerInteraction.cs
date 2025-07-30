using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private InteractionAction Actions;
    private GameObject interactionalObject = null;

    private void Awake()
    {
        Actions = new InteractionAction();
    }

    // Update is called once per frame
    void Update()
    {
        if (Actions.Interaction.Interaction.triggered && interactionalObject != null)
        {
            interactionalObject.GetComponent<IInteractable>()?.Interact();
        }
    }

    void OnEnable()
    {
        Actions.Enable();
    }

    void OnDisable()
    {
        Actions.Disable();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IInteractable>(out _))
        {
            interactionalObject = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactionalObject = null;
    }
}
