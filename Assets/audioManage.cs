
using Unity.VisualScripting;
using UnityEngine;

public class audioManage : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;




    public AudioClip background;
    public AudioClip death;
    public AudioClip point;
   public AudioClip buttonClick;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlayButtonClick()
   {
        if (buttonClick != null)
        {
           sfxSource.PlayOneShot(buttonClick);
        }
    }

public void playSFX(AudioClip clip)
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();  // Stop current SFX to avoid overlap
        }

        sfxSource.clip = clip;
        sfxSource.Play();
    }
}