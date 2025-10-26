using UnityEngine;
using UnityEngine.UI;


public class VolumeSettingsInitializer : MonoBehaviour
{

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;


    void OnEnable()
    {

        if (AudioManager.Instance != null)
        {
           
        }
        else
        {
            Debug.LogError("VolumeSettingsInitializer: AudioManager instance not found. Ensure it loads first.");
        }
    }
}
