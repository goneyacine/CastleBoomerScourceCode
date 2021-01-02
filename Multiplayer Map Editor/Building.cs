using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Building : MonoBehaviour
{
    private void Start()
    {
    editorManager = FindObjectOfType<EditorManager>();
    float myCastleObjectSpace = gameObject.GetComponent<Castle_Object_Manager>().castle_Object.space;
    if(editorManager.currentUsedSpace + myCastleObjectSpace <= editorManager.maxSpace){
    editorManager.currentUsedSpace += myCastleObjectSpace;
    hadFreeSpace = true;
    editorManager.UpdateFreeSpaceText();
    }
    else 
        Destroy(gameObject);
    }
    private void Update()
    {
      myMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      if(Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position,myMousePosition) <= cursorDistanceToSelect)
      editorManager.SetSelectedEditorObject(this);
     if(isSelected){
     if(editorManager.editorMode == 0)
     {
        foreach(GameObject obj in transfromTools){
        obj.SetActive(true);
    }
        foreach(GameObject obj in rotatingTools)
        obj.SetActive(false);
     }else if(editorManager.editorMode == 1)
     {
        foreach(GameObject obj in transfromTools)
        obj.SetActive(false);
        foreach(GameObject obj in rotatingTools)
        obj.SetActive(true);
     }else
     Debug.LogError("WRONG EDITOR TYPE (SHOULD BE EITHER 0 OR 1 ) YOU ENTERED << " + editorManager.editorMode + " >>");
     }else{
        foreach(GameObject obj in transfromTools)
         obj.SetActive(false);
        foreach(GameObject obj in rotatingTools)
        obj.SetActive(false);
     }
    
      //when the player still click on the mouse button and canTransform value is true we move our object
     if(Input.GetMouseButton(0) && canTransform)
     Transform();
     else if(Input.GetMouseButtonUp(0)){
     	canTransform = false;
        canRotate = false;
     }
     else if(Input.GetMouseButton(0) && canRotate)
     Rotate();
     oldMousePosition = myMousePosition;
     myOldPosition = transform.position;
}
    //so we need this function when we want to change the value of canTransform boolean ,for example we the player click a button to move the object
    public void SetCanTransform(bool canTransform){this.canTransform = canTransform;}
    public void SetCanRotate(bool canRotate){this.canRotate = canRotate;}
    
	public void Transform(){ transform.position = myOldPosition + (myMousePosition - oldMousePosition) * transformAxis * transformSpeed; }

	public void Rotate()
	{
     Vector2 oldMouseDirection = (oldMousePosition - myOldPosition) / Vector2.Distance(oldMousePosition,myOldPosition);
    float oldMouseRotation = Mathf.Atan2(oldMouseDirection.y, oldMouseDirection.x);

     Vector2 mouseDirection = (myMousePosition - (Vector2)transform.position) / Vector2.Distance(myMousePosition,transform.position);
    float NewMouseRotation = Mathf.Atan2(mouseDirection.y, mouseDirection.x);
    transform.eulerAngles += (NewMouseRotation - oldMouseRotation) * Vector3.forward * rotatingSpeed; 
	}
    public void SetAxisToX(){this.transformAxis = Vector2.right;}
    public void SetAxisToY(){this.transformAxis = Vector2.up;}
    public void SetAxisToAll(){this.transformAxis = Vector2.one;}
    private void OnDestroy()
    {
    if(hadFreeSpace){
    editorManager.currentUsedSpace -= gameObject.GetComponent<Castle_Object_Manager>().castle_Object.space;
    Debug.Log(" << Editor Object Destroyed >> ");
    editorManager.UpdateFreeSpaceText();
    }
}

	public bool canTransform;
	public bool canRotate;
    public Vector2 centerPosition;
    private Vector2 oldMousePosition;
    private Vector2 myMousePosition;
    private Vector2 myOldPosition;
    public Vector2 transformAxis = new Vector2(1,1);
    public float transformSpeed = 1f;
    public float rotatingSpeed = 1f;
    public List<GameObject> transfromTools;
    public List<GameObject> rotatingTools;
    public EditorManager editorManager;
    public bool isSelected;
    public float cursorDistanceToSelect = 1f;
    public GameObject transformObjectsParent;
    //when we create this object we try to find free space on the editor manager if we find space we set this to true if else it will be false
    public bool hadFreeSpace = false;
}