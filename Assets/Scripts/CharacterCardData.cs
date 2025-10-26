using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
public class CharacterCardData : MonoBehaviour
{
    [Header("Character Data")]
    [Tooltip("The name of the character")]
    public string characterName;

    [Tooltip("The character's stats (e.g., 'HP: 100\nMP: 50')")]
    [TextArea(3, 10)]
    public string characterStats;

    [Tooltip("A description of the character")]
    [TextArea(5, 15)]
    public string characterDescription;

    private static CharacterPanelDisplay panelDisplay;

    private Button thisButton;

    [System.Obsolete]
    void Start()
    {

        if (panelDisplay == null)
        {
            panelDisplay =FindObjectOfType<CharacterPanelDisplay>();
        }


        thisButton = GetComponent<Button>();
        if (thisButton != null)
        {

            thisButton.onClick.AddListener(DisplayMyInfo);
        }
        else
        {
            Debug.LogWarning("CharacterCardData script is on an object without a Button component!", this);
        }
    }

    void DisplayMyInfo()
    {
        if (panelDisplay != null)
        {

            panelDisplay.DisplayCharacter(this);
        }
        else
        {
            Debug.LogError("Could not find CharacterPanelDisplay in the scene!", this);
        }
    }
}
