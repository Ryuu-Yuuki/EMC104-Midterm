using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer masterMixer;

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;
    public AudioClip buttonClickClip;

    private const string MasterVolumeKey = "MasterVolume";
    private const string MusicVolumeKey = "MusicVolume";
    private const string SfxVolumeKey = "SfxVolume";
    public void PlayClickClip()
    {
        if (sfxAudioSource != null && buttonClickClip != null)
        {
            sfxAudioSource.PlayOneShot(buttonClickClip);
        }
        else
        {
            Debug.LogWarning("PlayClickClip: Missing SFX Audio Source or Button Click Clip assignment!");
        }
    }
    void Awake()        
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void LoadVolumeSettings()
    {

        float masterVol = PlayerPrefs.GetFloat(MasterVolumeKey, 1f);
        float musicVol = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        float sfxVol = PlayerPrefs.GetFloat(SfxVolumeKey, 1f);

        SetMixerVolume(MasterVolumeKey, masterVol);
        SetMixerVolume(MusicVolumeKey, musicVol);
        SetMixerVolume(SfxVolumeKey, sfxVol);
    }


    public void SetMixerVolume(string parameterName, float sliderValue)
    {
        if (masterMixer != null)
        {
            if (sliderValue == 0)
            {
                masterMixer.SetFloat(parameterName, -80f);
            }
            else
            {

                masterMixer.SetFloat(parameterName, Mathf.Log10(sliderValue) * 20);
            }
        }
    }

    public void PlayButtonClickSound()
    {
        if (sfxAudioSource != null && buttonClickClip != null)
        {
            if (!sfxAudioSource.enabled)
            {
                sfxAudioSource.enabled = true;
            }

            sfxAudioSource.PlayOneShot(buttonClickClip);
        }
    }

    public void SetMasterVolume(float sliderValue)
    {
        SetMixerVolume(MasterVolumeKey, sliderValue);
        PlayerPrefs.SetFloat(MasterVolumeKey, sliderValue);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float sliderValue)
    {
        SetMixerVolume(MusicVolumeKey, sliderValue);
        PlayerPrefs.SetFloat(MusicVolumeKey, sliderValue);
        PlayerPrefs.Save();
    }

    public void SetSfxVolume(float sliderValue)
    {
        SetMixerVolume(SfxVolumeKey, sliderValue);
        PlayerPrefs.SetFloat(SfxVolumeKey, sliderValue);
        PlayerPrefs.Save();
    }

}
