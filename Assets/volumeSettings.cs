
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    private void Start()
    {
        // Load saved volume values or use defaults
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        ApplyVolume("music", musicVolume);
        ApplyVolume("sfx", sfxVolume);
    }
    public void setMusicVolume()
    {
        ApplyVolume("music", musicSlider.value);
    }

    public void setSfxVolume()
    {
        ApplyVolume("sfx", sfxSlider.value);
    }

    public void saveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();
    }
    private void ApplyVolume(string parameter, float sliderValue)
    {
        // Ensure slider value is above zero to avoid log10(0)
        float volumeInDb = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        myMixer.SetFloat(parameter, volumeInDb);
    }

    public void cancelSettings()
    {
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float savedSfx = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        musicSlider.value = savedMusic;
        sfxSlider.value = savedSfx;

        ApplyVolume("music", savedMusic);
        ApplyVolume("sfx", savedSfx);
    }
}



