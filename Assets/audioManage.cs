
using UnityEngine;

public class audioManage : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;



    public AudioClip background;
    public AudioClip death;
    public AudioClip point;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}