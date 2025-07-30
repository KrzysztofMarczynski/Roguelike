using UnityEngine;

public class Key : MonoBehaviour
{
    private AudioManager audioManager;
    public bool key = false;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            key = true;
            audioManager.PlaySFX(audioManager.key);
            Destroy(gameObject);
        }
    }
}
