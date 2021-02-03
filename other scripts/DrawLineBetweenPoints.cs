using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineBetweenPoints : MonoBehaviour {
	public List<Transform> points;
	private LineRenderer lineRenderer;
	//the number of frames between line renderer positions update
	[Range(1,60)]
    public int MaxFrameNumToNextUpdate = 8;
 
    private int currentFrame; 

	private void OnEnable(){
		lineRenderer = GetComponent<LineRenderer>();
	}
	private void Update(){
		if(currentFrame < MaxFrameNumToNextUpdate)
		currentFrame ++;
		else {
			lineRenderer.positionCount = points.Count;
			for(int i = 0; i < points.Count;i++)
			lineRenderer.SetPosition(i,points[i].position);

			currentFrame = 0;
		}
	}
}