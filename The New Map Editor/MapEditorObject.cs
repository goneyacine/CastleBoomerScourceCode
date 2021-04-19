using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorObject : MonoBehaviour
{


   private void OnTriggerStay2D(Collider2D collider){
   if(collider.tag == "MouseFollower" && (Input.GetMouseButton(0) || Input.touchCount > 0))
   MapEditorManager.mapEditorManager.selectedMapEditorObject = this;
   }
   
}