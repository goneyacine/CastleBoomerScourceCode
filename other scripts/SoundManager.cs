using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public List<Sound> sounds;
    public static SoundManager soundManager;
    private void Awake()
    {
        if (soundManager == null)
            soundManager = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            if (sound.name == "music")
                sound.source.Play();
        }
    }
    public void UpdateSoundsVolume()
    {
        foreach(Sound sound in sounds)
        {
            if (sound.name == "music")
                sound.source.volume = sound.volume * (float)DataSerialization.GetObject("music");
            else
                sound.source.volume = sound.volume * (float)DataSerialization.GetObject("sound");

        }
    }
    public void Play(string name)
    {
        bool sourceFounded = false;
        foreach (Sound sound in sounds)
        {
            if(sound.name == name)
            {
                sound.source.Play();
                sourceFounded = true;
                break;
            }
            else
            {
                continue;
            }
        }
        if (sourceFounded)
            PrintWarningMessage("we can't find sound with name " + name);
    }
    public void PrintWarningMessage(string message) { Debug.LogWarning(message); }
}
[System.Serializable]
public class Sound {
    //the sound clip
    public AudioClip clip;
    //sound object name
    public string name;
    //sound clip volume
    [Range(0.0f,1.0f)]
    public float volume = 1f;
    //sound clip pitch
    [Range(.3f,3f)]
    public float pitch = .3f;
    //check if you want to loop the sound or not
    public bool loop = false;
    //the audio source commponet of this sound
    public AudioSource source;
}

