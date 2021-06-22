using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class ZOOM : MonoBehaviour
{
    public List<ZoomingData> zoomingData;
    public int targetZoomingDataIndex = 1;
    public Camera cam;
    private void Start()
    {
        UpdateData();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.O))
        ZoomOut();
        else if (Input.GetKeyDown(KeyCode.I))
        ZoomIn();
    }
    private void UpdateData()
    {
        try
        {
            cam.orthographicSize = zoomingData[targetZoomingDataIndex].camSize;
            transform.position = new Vector3(transform.position.x, zoomingData[targetZoomingDataIndex].position.y, transform.position.z);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
    }
    public void ZoomIn()
    {
        if (targetZoomingDataIndex - 1 >= 0)
        {
            targetZoomingDataIndex--;
            UpdateData();
        }
    }
    public void ZoomOut()
    {
        if (targetZoomingDataIndex + 1 < zoomingData.Count)
        {
            targetZoomingDataIndex++;
            UpdateData();
        }
    }
}
[System.Serializable]
public class ZoomingData 
{
    public Vector3 position;
    public float camSize;
}
