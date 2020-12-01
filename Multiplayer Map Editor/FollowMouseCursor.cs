using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
   private void Update(){
   	if(Input.GetMouseButtonDown(0))
   	gameObject.GetComponent<CircleCollider2D>().enabled = true;
   	else if(Input.GetMouseButtonUp(0))
   	gameObject.GetComponent<CircleCollider2D>().enabled = false;
   	transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   }
}
