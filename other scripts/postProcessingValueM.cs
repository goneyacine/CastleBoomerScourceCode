using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;
public class postProcessingValueM : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;
    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        UpdateVolume();
    }
    public void UpdateVolume()
    {
        postProcessVolume.weight = (float)DataSerialization.GetObject("postProcessingValue");
    }
    //adding more optimizations and work on update ui elements
}
