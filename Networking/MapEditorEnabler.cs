using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I Don't Need This Script
public class MapEditorEnabler : MonoBehaviour{
	private void OnEnable(){
		try{
		GameObject.FindGameObjectWithTag("map editor").SetActive(true);
		GameObject.FindGameObjectWithTag("1v1 choice").SetActive(false);
		Debug.Log("map editor enabled succesfuly");
		Destroy(gameObject);
		}catch(Exception e){ Debug.LogError(e); }

	}
}