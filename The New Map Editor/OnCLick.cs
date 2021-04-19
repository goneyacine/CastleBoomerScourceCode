using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCLick : MonoBehaviour
{  
    public UnityEvent onClick;
    public UnityEvent onClickEnd;
    private void OnTriggerStay2D(Collider2D other)
    {
     if(Input.GetMouseButton(0) || Input.touchCount > 0)
     onClick.Invoke();
	}
	 private void OnTriggerExit2D(Collider2D other)
    {
     if(Input.GetMouseButton(0) || Input.touchCount > 0)
     onClickEnd.Invoke();
	}

}
