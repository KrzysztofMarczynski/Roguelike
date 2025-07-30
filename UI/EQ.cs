using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private GameObject eq;
    private AudioManager audioManager;
    public bool EQ = true;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (EQ == true)
            {
                audioManager.PlaySFX(audioManager.EQShow);
                EQ = false;
            }
            else if (EQ == false)
            {
                audioManager.PlaySFX(audioManager.EQHide);
                EQ = true;
            }
            eq.SetActive(!eq.activeSelf);
        }
    }
}
