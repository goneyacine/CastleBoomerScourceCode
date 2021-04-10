using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layzer : MonoBehaviour
{
   public LayzerEndPoint endPoint;
   public Transform startPoint;
   public bool isOn = false;
   
    void OnCollisionEnter2D(Collision2D other){
    	isOn= !isOn; 
    	endPoint.transform.position = startPoint.position;
    	endPoint.layzerIsOn = isOn;
	}
}
