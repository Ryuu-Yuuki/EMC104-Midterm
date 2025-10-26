using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VolumeSliderRelinker : MonoBehaviour
{

    public enum VolumeType { Master, Music, SFX }


    public VolumeType type;

    private Slider slider;
    private string mixerParamKey; 
    private UnityAction<float> setVolumeAction; 

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (AudioManager.Instance == null || slider == null)
        {
            Debug.LogError($"Relinker failed on {gameObject.name}: AudioManager or Slider component missing.", this);
            return;
        }

        switch (type)
        {
            case VolumeType.Master:
                mixerParamKey = "MasterVolume";
                setVolumeAction = AudioManager.Instance.SetMasterVolume;
                break;
            case VolumeType.Music:
                mixerParamKey = "MusicVolume";
                setVolumeAction = AudioManager.Instance.SetMusicVolume;
                break;
            case VolumeType.SFX:
                mixerParamKey = "SfxVolume";
                setVolumeAction = AudioManager.Instance.SetSfxVolume;
                break;
        }


        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener(setVolumeAction);


        float savedValue = PlayerPrefs.GetFloat(mixerParamKey, 0.5f);
        savedValue = Mathf.Max(savedValue, 0.0001f);


        slider.SetValueWithoutNotify(savedValue);

        AudioManager.Instance.SetMixerVolume(mixerParamKey, savedValue);
    }
}
