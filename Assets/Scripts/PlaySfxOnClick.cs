using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class PlaySfxOnClick : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogError($"PlaySfxOnClick: No Button component found on {gameObject.name}");
        }
    }

    private void PlaySound()
    {

        AudioManager audioManagerInstance = AudioManager.Instance;

        if (audioManagerInstance != null)
        {

            audioManagerInstance.PlayClickClip();
        }
        else
        {
            Debug.LogError("SFX: AudioManager.Instance is NULL. Button click failed.");
        }
    }
}
