using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Key key;
    private Animator animator;
    private AudioManager audioManager;
    CapsuleCollider2D capsuleCollider2D;

    void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        key = FindAnyObjectByType<Key>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void Interact()
    {
        if (key.key == true)
        {
            audioManager.PlaySFX(audioManager.slidingDoor);
            animator.SetTrigger("Open");
            Destroy(capsuleCollider2D);
            Destroy(gameObject, 0.6f);
        }
    }

}
