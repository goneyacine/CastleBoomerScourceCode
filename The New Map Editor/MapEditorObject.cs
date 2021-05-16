using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorObject : MonoBehaviour
{

   private void OnTriggerStay2D(Collider2D other){
   if(other.tag == "MouseFollower" && (Input.GetMouseButtonDown(0) || Input.touchCount > 0)){
   MapEditorManager.mapEditorManager.selectedMapEditorObject = this;
     }
   }
   
}