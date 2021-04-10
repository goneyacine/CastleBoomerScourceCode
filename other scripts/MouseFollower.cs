using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    
    void Update()
    {   if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x,Camera.main.ScreenToWorldPoint(touch.position).y); 
        }
        else
         transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);   
    }
}
