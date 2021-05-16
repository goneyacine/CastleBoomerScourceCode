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
   transformTool.gameObject.SetActive(true);
   rotatingTool.gameObject.SetActive(true);  
   transformTool.position = selectedMapEditorObject.gameObject.transform.position;
   rotatingTool.position =  selectedMapEditorObject.gameObject.transform.position;
  }else {
  	transformTool.gameObject.SetActive(false);
    rotatingTool.gameObject.SetActive(false);
  }
  //doing the rotating & the trasforming things
  if(selectedMapEditorObject != null){
    if(Input.GetMouseButton(0) || Input.touchCount > 0){
    	if(playerIsRotating)
    	Rotate();
    	else if(playerIsTransforming)
    	Transform();
    	
    }
  }
  if(selectedMapEditorObject != null)
  myOldPosition = (Vector2)selectedMapEditorObject.transform.position;
  oldMousePosition = (Vector2)mouseFollower.position;
 }
 public void Rotate()
 {
    Vector2 mouseDirection = ((Vector2)mouseFollower.position - (Vector2)selectedMapEditorObject.transform.position) / Vector2.Distance((Vector2)mouseFollower.position,selectedMapEditorObject.transform.position);
    selectedMapEditorObject.transform.eulerAngles = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg * Vector3.forward; 
  }
  public void Transform()
  {
   selectedMapEditorObject.transform.position = myOldPosition + ((Vector2)mouseFollower.position - oldMousePosition) * transformAxis * transformSpeed;
  }

  public void SetPlayerIsRotating(bool value){this.playerIsRotating = value;}
  public void SetPlayerIsTransfroming(bool value){this.playerIsTransforming = value;}
  
  public void SetAxisToX(){this.transformAxis = Vector2.right;}
  public void SetAxisToY(){this.transformAxis = Vector2.up;}
  public void SetAxisToAll(){this.transformAxis = Vector2.one;}

  public void DestroySelectedObject()
  {
   Destroy(selectedMapEditorObject.gameObject);
  }

 public static MapEditorManager mapEditorManager; 
 //the selected map editor object 
 public MapEditorObject selectedMapEditorObject;
 //the trasnform of the transform & rotating tools 
 public Transform transformTool;
 public Transform rotatingTool; 
 //the mouse follower transform (the mouse follower follows the mouse & also follows touch)
 public Transform mouseFollower;

 private bool playerIsRotating = false;
 private bool playerIsTransforming = false;

 private Vector2 myOldPosition;
 private Vector2 oldMousePosition;

 public Vector2 transformAxis;
 
 [Range(.001f,500f)]
 public float transformSpeed = 1.5f;
 
}