using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorManager : MonoBehaviour
{
  public MapEditorManager(){
  if(mapEditorManager == null)
  mapEditorManager = this;
  else
  Destroy(this);
 }
 private void Update(){
  //setting the position of the transform & rotatings tools
  if(selectedMapEditorObject != null)
  {
   trasnformTool.SetActive(false);
   rotatingTool.SetActive(false);  
   transformTool.position = selectedMapEditorObject.gameObject.transform.position;
   rotatingTool.position =  selectedMapEditorObject.gameObject.transform.position;
  }else {
  	transformTool.SetActive(false);
    rotatingTool.SetActive(false);
  }
 }
  

 public static MapEditorManager mapEditorManager; 
 //the selected map editor object 
 public MapEditorObject selectedMapEditorObject;
 //the trasnform of the transform & rotating tools 
 public Transform trasnformTool;
 public Transform rotatingTool; 
}