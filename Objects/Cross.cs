using UnityEngine;

public class Cross : MonoBehaviour
{
    private AudioManager audioManager;
    public bool cross = false;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            cross = true;
            audioManager.PlaySFX(audioManager.key);
            Destroy(gameObject);
        }
    }
}
