using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
[RequireComponent(typeof(Camera))]
public class CameraShakeEffect : MonoBehaviour
{
	public Vector2 screenSizeChangingRange;
	public Vector2 postionChangingRange;
	public Vector2 rotationChangingrRange;
	public int frames = 60;
	public int timeBetweenFrames = 45;
	public void Shake()
	{
		Camera cam = gameObject.GetComponent<Camera>();
		Vector3 originalCamPosition = transform.position;
		Vector3 originalCamRotation = transform.eulerAngles;
		float originalCamSize = cam.orthographicSize;

		float screenSizeChangeValue = UnityEngine.Random.Range(screenSizeChangingRange.x, screenSizeChangingRange.y);
		Vector3 positionChangingValue = new Vector2(UnityEngine.Random.Range(postionChangingRange.x, postionChangingRange.y),
		        UnityEngine.Random.Range(postionChangingRange.x, postionChangingRange.y));
		Vector3 rotationChangingrValue = new Vector2(UnityEngine.Random.Range(rotationChangingrRange.x, rotationChangingrRange.y),
		        UnityEngine.Random.Range(rotationChangingrRange.x, rotationChangingrRange.y));
		for (int i = 0; i < frames; i++)
		{
			cam.orthographicSize += screenSizeChangeValue / frames;
			transform.position += positionChangingValue / frames;
			transform.eulerAngles += rotationChangingrValue / frames;
			Thread.Sleep(timeBetweenFrames);
		}
		for (int i = 0; i < frames; i++)
		{
			cam.orthographicSize -= screenSizeChangeValue / frames;
			transform.position -= positionChangingValue / frames;
			transform.eulerAngles -= rotationChangingrValue / frames;
			Thread.Sleep(timeBetweenFrames);
		}

	}
}
