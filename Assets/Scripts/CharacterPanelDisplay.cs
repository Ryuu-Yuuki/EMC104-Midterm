using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class CharacterPanelDisplay : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("The TextMeshPro UI element to display the name")]
    public TextMeshProUGUI nameText;

    [Tooltip("The TextMeshPro UI element to display the stats")]
    public TextMeshProUGUI statsText;

    [Tooltip("The TextMeshPro UI element to display the description")]
    public TextMeshProUGUI descriptionText;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("Canvas Group component is missing on the Details Panel!", this);
        }

        ClosePanel(0f); 
    }
    public void DisplayCharacter(CharacterCardData data)
    {
        if (data == null) return;

        if (nameText != null)
        {
            nameText.text = data.characterName;
        }

        if (statsText != null)
        {
            statsText.text = data.characterStats;
        }

        if (descriptionText != null)
        {
            descriptionText.text = data.characterDescription;
        }
        SetPanelVisibility(1f, true);
    }

    public void ClosePanel(float alpha = 0f)
    {
        SetPanelVisibility(alpha, false);
    }

    private void SetPanelVisibility(float alpha, bool interactable)
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = alpha;
            canvasGroup.interactable = interactable;
            canvasGroup.blocksRaycasts = interactable;
        }
    }
}