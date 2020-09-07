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
            DataSerialization.SaveData(false, "playerCurrentLevel");
            DataSerialization.SaveData(0, "selectedLevel");
            List<BulletData> openedBullets = new List<BulletData>();
            openedBullets.Add(new BulletData("default bullet", 3));
            DataSerialization.SaveData(openedBullets, "openedBullets");
            List<BulletData> selectedBullets = new List<BulletData>();
            selectedBullets.Add(new BulletData("default bullet", 2));
            DataSerialization.SaveData(selectedBullets,"selectedBullets");
            DataSerialization.SaveData("AAA", "default cannon base");
            DataSerialization.SaveData("AAA", "default cannon muzzle base");
            DataSerialization.SaveData("AAA", "default ammunition store");

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
[System.Serializable]
public class BulletData
{
    public string name;
    public int number;
    public BulletData(string name,int number)
    {
        this.name = name;
        this.number = number;
    }
}
