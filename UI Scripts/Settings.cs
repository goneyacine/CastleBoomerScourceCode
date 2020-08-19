using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;
    public Slider postProcessingSlider;

    private void Update()
    {
        DataSerialization.SaveData(soundSlider.value, "sound");
        DataSerialization.SaveData(musicSlider.value, "music");
        DataSerialization.SaveData(postProcessingSlider.value, "postProcessingValue");
    }
}
