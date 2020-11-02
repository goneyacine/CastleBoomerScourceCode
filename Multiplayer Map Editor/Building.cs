using System;
using System.Collections;
using System.Collections.Genric;
using UnityEngine;

public class Building{
    private void Update()
    {
     myMousePosition = Camera.main.ScreenToWorldPosition(Input.mousePostision);
      //when the player still click on the mouse button and canTransform value is true we move our object
     if(Input.GetMouseButton(0) && canTransform)
     Transform();
     else if(!Input.GetMouseButton(0))
     	canTransform = false;
     else if(Input.GetMouseButton(0) && canRotate)
     Rotate();
     oldMousePosition = myMousePosition;
     myOldPosition = transform.postion;
}
    //so we need this function when we want to change the value of canTransform boolean ,for example we the player click a button to move the object
    public void setCanTransformValue(bool canTransform){this.canTransform = canTransform;}
    public void setCanRotateValue(bool canRotate){this.canRotate = canRotate;}
    
	public void Transform(){ transform.postion += myMousePostision - oldMousePosition; }

	public void Rotate()
	{
     Vector2 oldMouseDirection = (oldMousePosition - myOldPosition) / Vector2.Distance(oldMousePosition,myOldPosition);
    float oldMouseRotation = Mathf.Atan2(oldMouseDirection.y, oldMouseDirection.x);

     Vector2 mouseDirection = (myMousePosition - transform.postion) / Vector2.Distance(myMousePosition,transform.postion);
    float NewMouseRotation = Mathf.Atan2(mouseDirection.y, mouseDirection.x);
    transform.eulerAngles = NewMouseRotation - oldMouseRotation; 
	}

	//when the moved object try to go out side the building area we move his postition to the center
	private void Collider2D.OnTriggerExit2D(Collider2D other){ transform.postion = centerPosition; }

	public bool canTransform;
	public bool canRotate;
    public Vector2 centerPosition;
    private Vector2 oldMousePosition;
    private Vector2 myMousePostision;
    private Vector2 myOldPosition;
}