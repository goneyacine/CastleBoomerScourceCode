using UnityEngine;
using UnityEngine.UI;

//this class display the needed informations of the target level to the player
public class LevelDisplayUIManager : MonoBehaviour
{
    public LevelObject targetLevelObject;
    public Image LevelIconImageDisplay;
    public Text LevelNameTextDisplay;

    private void Start()
    {
       UpdateUI();
    }
    public void UpdateUI()
    {
        LevelIconImageDisplay.sprite = targetLevelObject.icon;
        LevelNameTextDisplay.text = targetLevelObject.name;
    }
}
