using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Transform tran;

    private void Update()
    {
        //find the world position of the mouse
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //trun the position of tran var to vector2
        Vector2 tran2DPosition = new Vector2(tran.position.x, tran.position.y);
        //the direction that the cannon should look at 
        Vector2 direction = new Vector2(mouseWorldPosition.x - tran2DPosition.x,mouseWorldPosition.y - tran2DPosition.y) / 
            Vector2.Distance(mouseWorldPosition,tran2DPosition);
        float lookingAngle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
        //now we can look at the mouse cursor
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,lookingAngle + 90);
        

    }
 


}
