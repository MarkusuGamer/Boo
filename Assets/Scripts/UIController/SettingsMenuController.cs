using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    // ---- / Serialized Variables / ---- //
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundsSlider.onValueChanged.AddListener(SetSoundsVolume);
    }

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20);
    }
    
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);
    }
    
    public void SetSoundsVolume(float level)
    {
        audioMixer.SetFloat("soundsVolume", Mathf.Log10(level) * 20);
    }
    
    public void GoBack()
    {
        gameObject.SetActive(false);
    }
}
