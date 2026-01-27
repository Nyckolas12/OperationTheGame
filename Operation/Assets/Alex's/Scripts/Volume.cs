using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider musicVol;
    public Slider SFXVol;
    public AudioMixer audioMixer;

    void Start()
    {
        float savedMusicVol = PlayerPrefs.GetFloat("Music", 1f);
        float savedSFXVol = PlayerPrefs.GetFloat("SFX", 1f);
        musicVol.value = savedMusicVol;
        SFXVol.value = savedSFXVol;
        SetVolume(savedMusicVol);
        SetVolume(savedSFXVol);
    }

    public void SetVolume(float value)
    {
        float vol = Mathf.Log10(value) * 20;
        audioMixer.SetFloat("Music", vol);
        audioMixer.SetFloat("SFX", vol);
        PlayerPrefs.SetFloat("Music", value);
        PlayerPrefs.SetFloat("SFX", value);
        PlayerPrefs.Save();
    }
}
