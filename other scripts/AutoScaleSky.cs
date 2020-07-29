using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaleSky : MonoBehaviour
{
    public Camera camera;
    private Vector2 startScale;
    private float startCameraSize;
    private void Start()
    {
        startScale = transform.localScale;
        startCameraSize = camera.orthographicSize;
    }
    private void Update()
    {
        transform.localScale = new Vector2(startScale.x * camera.orthographicSize / startCameraSize,
            startScale.y * camera.orthographicSize / startCameraSize);
    }
}
