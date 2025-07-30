using Unity.VisualScripting;
using UnityEngine;

public class KeyShow : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] public Sprite img;
    private AudioManager audioManager;

    void Awake()
    {
        key.SetActive(false);
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            key.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.FShow);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.FHide);
            key.SetActive(false);
        }
    }
}
