using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EditorManager : MonoBehaviour
{
  //updating the free space text
  public void UpdateFreeSpaceText(){freeSpaceText.text = "Free Space : " + (maxSpace - currentUsedSpacet).toString();}
  //setting something
  public void SetEditorMode(int editorMode){this.editorMode = editorMode;}
  public void SetSelectedEditorObject(Building SelectedEditorObject){
  	if(this.SelectedEditorObject != null)
  	this.SelectedEditorObject.isSelected = false;

  	this.SelectedEditorObject = SelectedEditorObject;
  	this.SelectedEditorObject.isSelected = true;
  } 
  public void DestroySelectedObject(){
  	if(this.SelectedEditorObject != null)
  	Destroy(this.SelectedEditorObject.gameObject);
  }
  private Building SelectedEditorObject;
   // transformMode = 0 & rotationMode = 1
  public int editorMode = 0;
  //the max space of editor obejcts
  public float maxSpace;
  //the current used space 
  public float currentUsedSpace;
  //this text displays the free space 
  public Text freeSpaceText;
}
