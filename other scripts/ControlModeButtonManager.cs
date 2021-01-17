using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
public class ControlModeButtonManager : MonoBehaviour {
	private void OnEnable(){
    UpdateData();
	}
	public void UpdateData(){
		string controlMode =  DataSerialization.GetObject("ControlMode") as string;
		if(controlMode.Equals(MyControlMode))
		GetComponent<Image>().sprite = isSelectedImage;
		else 
		GetComponent<Image>().sprite = notSelectedImage;
	}
	public void SelectMe(){
		 DataSerialization.SaveData(MyControlMode, "ControlMode");
		 UpdateData();
		 foreach(ControlModeButtonManager manager in otherButtonManagers)
		  manager.UpdateData();
	}
	public Sprite isSelectedImage;
	public Sprite notSelectedImage;
	public string MyControlMode = "Mouse";
	public List<ControlModeButtonManager> otherButtonManagers;
}