using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            setMusicVolume();
            setSFXVolume();
        }
    }
    public void setMusicVolume()
    {
        float vol = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("musicVolume", vol);
    }
    public void setSFXVolume()
    {
        float vol = sfxSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("sfxVolume", vol);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        setMusicVolume();
        setSFXVolume();
    }
}
