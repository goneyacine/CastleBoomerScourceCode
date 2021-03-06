﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraZooming : MonoBehaviour
{
    //so this list contains sorted values of right mouse button and zooming out value of this time
    //NOTE : x value is the time , y value is the zooming out value and the z value is the y position
    public List<Vector3> ClickingTime_ZoomingValue;
    //the the time when the player clicks the right mouse button, if the right mouse button is relased the value will be -1
    private float time = 0f;
    //the size camera must have
    private float camSize;
    //the default camera size
    public float defaultCamSize;
    //the default y positon of the camera
    public float defaultYpos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            time = Time.time;
        else if (Input.GetMouseButton(0))
        {
            //trying to find the corect camera size using right mouse button clicking time and ClickingTime_ZoomingValue list
            for (int i = 0; i < ClickingTime_ZoomingValue.Count; i++)
            {

                float ThisTime = Time.time - time;
                if (i + 1 < ClickingTime_ZoomingValue.Count && ClickingTime_ZoomingValue[i].x <= ThisTime && ClickingTime_ZoomingValue[i + 1].x >= ThisTime)
                {

                    camSize = ClickingTime_ZoomingValue[i].y;
                    transform.position = new Vector3(transform.position.x, Vector2.Lerp(Vector2.up * transform.position.y, Vector2.up * ClickingTime_ZoomingValue[i].z,.125f).y, transform.position.z);

                }
                else if (i + 1 >= ClickingTime_ZoomingValue.Count && ClickingTime_ZoomingValue[i].x <= ThisTime)
                {

                    camSize = ClickingTime_ZoomingValue[i].y;
                    transform.position = new Vector3(transform.position.x, Vector2.Lerp(Vector2.up * transform.position.y, Vector2.up * ClickingTime_ZoomingValue[i].z, .125f).y, transform.position.z);


                }

            }

        }
        else
        {

            camSize = defaultCamSize;
            transform.position = new Vector3(transform.position.x, Vector2.Lerp(Vector2.up*transform.position.y,Vector2.up * defaultYpos,.125f).y, transform.position.z);

        }

        //zoom in and zoom out functionality
        // trying to move smoothly from the old size to the new one
        gameObject.GetComponent<Camera>().orthographicSize = Vector2.Lerp(Vector2.right *
        gameObject.GetComponent<Camera>().orthographicSize, Vector2.right * camSize, .125f).x;

    }
}
