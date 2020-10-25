using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;
    public Slider postProcessingSlider;
    private float soundVolume;
    private float musicVolume;
    private float postProcessingVolume;
    private SoundManager soundManager;
    private postProcessingValueM postProcessingValueManager;

    private void Start()
    {
        soundVolume = soundSlider.value;
        musicVolume = musicSlider.value;
        postProcessingVolume = postProcessingSlider.value;
        soundManager = FindObjectOfType<SoundManager>();
        postProcessingValueManager = FindObjectOfType<postProcessingValueM>();
    }

    private void Update()
    {
        if (soundVolume != soundSlider.value)
        {
            DataSerialization.SaveData(soundSlider.value, "sound");
            soundVolume = soundSlider.value;
            soundManager.UpdateSoundsVolume();
        }
        if (musicVolume != musicSlider.value)
        {
            DataSerialization.SaveData(musicSlider.value, "music");
            musicVolume = musicSlider.value;
            soundManager.UpdateSoundsVolume();
        }
        if (postProcessingSlider.value != postProcessingVolume)
        {
            DataSerialization.SaveData(postProcessingSlider.value, "postProcessingValue");
            postProcessingVolume = postProcessingSlider.value;
            postProcessingValueManager.UpdateVolume();
        }
    }
}
