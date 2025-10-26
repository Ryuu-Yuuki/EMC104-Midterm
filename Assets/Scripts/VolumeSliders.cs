using UnityEngine;

public class VolumeSliders : MonoBehaviour
{
    public GameObject optionsSlider;
    internal float value;

    void Start()
    {
        if (optionsSlider != null)
        {
            optionsSlider.SetActive(false);
        }
    }
    public void ToggleSliderVisibility()
    {

        bool isActive = optionsSlider.activeSelf;

        optionsSlider.SetActive(!isActive);
    }
}
