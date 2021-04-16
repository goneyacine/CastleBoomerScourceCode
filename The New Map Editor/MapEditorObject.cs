using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorObject : MonoBehaviour
{
  private void OnTriggerStay2D(Collider2D collider){
   if(collider.tag == "Mouse Follower" && Input.AnyKey())
   MapEditorManager.mapEditorManager.selectedMapEditorObject = this;
  }
}