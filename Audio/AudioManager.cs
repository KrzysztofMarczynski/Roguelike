using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSrc;
    [SerializeField] AudioSource SFXSrc;
    [SerializeField] AudioSource runSrc;

    [Header("Audio Clip")]
    public AudioClip music;
    public AudioClip jump;
    public AudioClip fire;
    public AudioClip death;
    public AudioClip run;
    public AudioClip alaalemniewszystkoboli;
    public AudioClip teleport;
    public AudioClip button;
    public AudioClip bossjump;
    public AudioClip coin;
    public AudioClip heart;
    public AudioClip saw;
    public AudioClip door;
    public AudioClip key;
    public AudioClip bulletFire;
    public AudioClip bulletHit;
    public AudioClip enemyDied;
    public AudioClip CardTake;
    public AudioClip EQShow; 
    public AudioClip EQHide;
    public AudioClip FShow;
    public AudioClip FHide;
    public AudioClip slidingDoor;

    void Awake()
    {
        musicSrc.clip = music;
        musicSrc.loop = true;

        runSrc.clip = run;
        runSrc.loop = true;
    }

    private void Start()
    {
        musicSrc.clip = music;
        musicSrc.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSrc.PlayOneShot(clip);
    }

    public void PlayRun()
    {
        if (!runSrc.isPlaying)
            runSrc.Play();
    }

    public void StopRun()
    {
        if (runSrc.isPlaying)
        {
            runSrc.Stop();
        }
    }
}
