using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : MonoBehaviour
{
    [SerializeField] private Slider effectsVolume;
    [SerializeField] private Slider musicVolume;

    private void Start()
    {
        Debug.Log(GetPref("EffectsVolume", 1f));
        effectsVolume.value = GetPref("EffectsVolume", 1f);
        musicVolume.value = GetPref("MusicVolume", 1f);
    }

    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
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
