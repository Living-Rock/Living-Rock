using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerPrefsManager : MonoBehaviour
{
    [SerializeField] private Slider effectsVolume;
    [SerializeField] private Slider musicVolume;

    [SerializeField] AudioMixer audioMixer;

    private void Start()
    {
        effectsVolume.value = GetPref("EffectsVolume", 1f);
        musicVolume.value = GetPref("MusicVolume", 1f);

        UpdateMusicVolume();
        UpdateEffectVolume();
    }

    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();

        if(key == "EffectsVolume")
        {
            audioMixer.SetFloat("sfxVol", 10 * Mathf.Log(Mathf.Clamp(effectsVolume.value, 0.0000001f, 1.0f)));
        }
        if(key == "MusicVolume")
        {
            audioMixer.SetFloat("musicVol", 10 * Mathf.Log(Mathf.Clamp(musicVolume.value, 0.0000001f, 1.0f)));
        }
    }

    private float GetPref(string key, float placeholder)
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetFloat(key) : placeholder;
    }

    public void UpdateEffectVolume()
    {
        SetPref("EffectsVolume", effectsVolume.value);
    }

    public void UpdateMusicVolume()
    {
        SetPref("MusicVolume", musicVolume.value);
    }
}
