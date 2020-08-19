using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class InitialDataLoader : MonoBehaviour
{
    public Slider postProcessingSlider;
    public Slider soundSlider;
    public Slider musicSlider;
    private void Awake()
    {
        if (!DataSerialization.fileExists(Application.persistentDataPath + "/firstTimePlayer.txt"))
        {
            DataSerialization.SaveData(true, "firstTimePlayer");
            DataSerialization.SaveData(0, "gold");
            DataSerialization.SaveData("PLAYER__NAME", "name");
            DataSerialization.SaveData(0, "money");
            DataSerialization.SaveData(0, "xp");
            DataSerialization.SaveData(1,"LV");
            DataSerialization.SaveData(1, "lastOpenedLevel");
            DataSerialization.SaveData(1.0f, "postProcessingValue");
            DataSerialization.SaveData(false,"IsThisLastOpenedLevel");
            DataSerialization.SaveData(1.0f, "sound");
            DataSerialization.SaveData(1.0f, "music");
            List<int> stars = new List<int>();
            stars.Add(0);
            DataSerialization.SaveData(stars, "singlePlayerStars");
            DataSerialization.SaveData(false, "playerCurrentLevel");
            DataSerialization.SaveData(0, "selectedLevel");
        }
        setUpSettingPanelValues();
    }
    private void setUpSettingPanelValues()
    {
        soundSlider.value = (float)DataSerialization.GetObject("sound");
        postProcessingSlider.value = (float)DataSerialization.GetObject("postProcessingValue");
        musicSlider.value = (float)DataSerialization.GetObject("music");
    }
}
