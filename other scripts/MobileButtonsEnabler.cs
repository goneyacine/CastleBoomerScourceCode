using System;
using UnityEngine;
using System.Collections;

public class MobileButtonsEnabler : MonoBehaviour {
	private void Start(){
    if(DataSerialization.GetObject("ControlMode") as string == "Touche")
     mobileButtonsParent.SetActive(true);
	}
  public GameObject mobileButtonsParent;
}