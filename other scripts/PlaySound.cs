using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
   public void Play(string name) {
        try {
            FindObjectOfType<SoundManager>().Play(name); 
        }catch(Exception e)
        {
            Debug.LogError(e);
        }

        }
}
