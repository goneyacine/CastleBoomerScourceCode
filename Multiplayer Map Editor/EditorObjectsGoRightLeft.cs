using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorObjectsGoRightLeft : MonoBehaviour {
	
	private void OnEnable(){
		UpdateUI();
	}

	public void SetCenterIndex(int centerIndex){
     if(centerIndex < 0)
     this.centerIndex = EditorObjects.Count - 1;
     else if (centerIndex > EditorObjects.Count - 1)
     this.centerIndex = 0;
     else 
     this.centerIndex = centerIndex;
     UpdateUI();
	}
	public void GoLeft(){ SetCenterIndex(this.centerIndex - 1); }
	public void GoRight(){ SetCenterIndex(this.centerIndex + 1); }
	public void UpdateUI(){
    if(EditorObjects.Count >= 1){
    dragDropObjects[1].gameObject.SetActive(true);
    dragDropObjects[1].gameObject.GetComponent<Drag_Drop>().castleObject = EditorObjects[centerIndex];
    dragDropObjects[1].gameObject.GetComponent<Drag_Drop>().OnChangeCastleObject();
}

    if(centerIndex == 0)
    dragDropObjects[0].gameObject.SetActive(false);
    else
    dragDropObjects[0].gameObject.SetActive(true);

    if(EditorObjects.Count == 1 || centerIndex + 1 == EditorObjects.Count)
    dragDropObjects[2].gameObject.SetActive(false);
    else if (EditorObjects.Count > 1 && centerIndex + 1 != EditorObjects.Count)
    dragDropObjects[2].gameObject.SetActive(true);
    else if(EditorObjects.Count == 0) {
     dragDropObjects[0].gameObject.SetActive(false);	
     dragDropObjects[1].gameObject.SetActive(false);
     dragDropObjects[2].gameObject.SetActive(false);	
    }
  
    if(centerIndex + 1 <= EditorObjects.Count - 1){
    dragDropObjects[2].gameObject.GetComponent<Drag_Drop>().castleObject = EditorObjects[centerIndex + 1];
    dragDropObjects[2].gameObject.GetComponent<Drag_Drop>().OnChangeCastleObject();
    }
    if(centerIndex - 1 >= 0){
    dragDropObjects[0].gameObject.GetComponent<Drag_Drop>().castleObject = EditorObjects[centerIndex - 1];
    dragDropObjects[0].gameObject.GetComponent<Drag_Drop>().OnChangeCastleObject();
    }
}

	public int centerIndex;
    public List<Castle_Object> EditorObjects;
	public List<GameObject> dragDropObjects;

}