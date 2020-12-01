using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_Button : MonoBehaviour
{
	public Building building;
	//the type of the button is something like "rotate,transform.x,transform.all or transform.y"
	public string buttonType;
    private void OnTriggerEnter2D(Collider2D other){
    	if(other.tag == "MouseFollower"){
          if(buttonType == "rotate"){
          	building.SetCanRotate(true);
          	building.SetCanTransform(false);
          }else if (buttonType == "transform.all"){
          	building.SetAxisToAll();
          	building.SetCanRotate(false);
          	building.SetCanTransform(true);
          }else if (buttonType == "transform.x"){
          	building.SetAxisToX();
          	building.SetCanRotate(false);
          	building.SetCanTransform(true);
          }else if (buttonType == "transform.y"){
          	building.SetAxisToY();
          	building.SetCanRotate(false);
          	building.SetCanTransform(true);
          }else {Debug.LogError("Wrong Button Type Value // You Typed <<" + buttonType + ">>");}
    	}
    }
}
