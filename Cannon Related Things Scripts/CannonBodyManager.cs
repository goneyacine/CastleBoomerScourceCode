using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CannonBodyManager : MonoBehaviour
{
    public CannonBody cannonBody;

    private void Update()
    {
        //set the scale
        transform.localScale = cannonBody.scale;
        //set the local position
        transform.localPosition = cannonBody.localPos;
        //set the texture (sprite)
        gameObject.GetComponent<SpriteRenderer>().sprite = cannonBody.texture;
        //set the color 
        gameObject.GetComponent<SpriteRenderer>().color = cannonBody.color;
    }
}
