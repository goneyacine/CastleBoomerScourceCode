using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrround_Element_Scaler : MonoBehaviour
{
    public float scalingValue;
    public Vector2 maxMinScale;
    private float randomScale;
    private void Start()
    {
        randomScale = transform.localScale.y;
    }
    private void Update()
    {
        if (randomScale == transform.localScale.y || transform.localScale.y < maxMinScale.x || transform.localScale.y > maxMinScale.y)
            randomScale = Random.Range(maxMinScale.x, maxMinScale.y);
        else
        {
            if (transform.localScale.y > randomScale)
                transform.localScale -= Vector3.up * scalingValue;
            else if (transform.localScale.y < randomScale)
                transform.localScale += Vector3.up * scalingValue;

        }
    }
}
