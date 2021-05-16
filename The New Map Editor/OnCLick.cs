using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCLick : MonoBehaviour
{  
    public UnityEvent onClick;
    public UnityEvent onClickEnd;
    private bool screenHasBeenTouched = false;
    private void OnTriggerStay2D(Collider2D other)
    {
      if(other.tag == "MouseFollower"){
     if(Input.GetMouseButtonDown(0) || Input.touchCount > 0)
     onClick.Invoke();
	  }
    }	
	 private void Update()
    {
     
     if(Input.GetMouseButtonUp(0) || (Input.touchCount == 0 && screenHasBeenTouched))
     onClickEnd.Invoke();


     if(Input.touchCount >= 1)
     screenHasBeenTouched = true;
     else 
     screenHasBeenTouched = false;
	}

}
