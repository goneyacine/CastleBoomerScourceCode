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
    }
    private void Update()
    {
        postProcessVolume.weight = (float)DataSerialization.GetObject("postProcessingValue");
    }
}
