using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Transform tran;
    private float offest;
    public float minAngle;
    public float maxAngle;
    [Range(0, 1)]
    public float smoothValue = .125f;
    private void Update()
    {

        //find the world position of the mouse
        Vector2 mouseWorldPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //trun the position of tran var to vector2
        Vector2 tran2DPosition = new Vector2(tran.position.x, tran.position.y);
        //find the direction betwen the mouse position and the tran position
        Vector2 direction = (mouseWorldPosition - tran2DPosition) / Mathf.Abs(Vector2.Distance(tran2DPosition,mouseWorldPosition));
        //find the angle of the direction var
        float angle = offest + (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); 
        //rotate the tran Transform smoothly to the new angle
        if((tran.eulerAngles.z > minAngle  && tran.eulerAngles.z < maxAngle) || (tran.eulerAngles.z <= minAngle && angle >= minAngle ) || (tran.eulerAngles.z >= maxAngle && angle <= maxAngle))
        tran.eulerAngles = Vector3.Lerp(tran.eulerAngles, new Vector3(tran.eulerAngles.x, tran.eulerAngles.y, angle), smoothValue); 
        else if ((tran.eulerAngles.z <= minAngle && angle < minAngle))
            tran.eulerAngles = Vector3.Lerp(tran.eulerAngles, new Vector3(tran.eulerAngles.x, tran.eulerAngles.y, minAngle), smoothValue);
        else if ((tran.eulerAngles.z >= maxAngle && angle > maxAngle))
            tran.eulerAngles = Vector3.Lerp(tran.eulerAngles, new Vector3(tran.eulerAngles.x, tran.eulerAngles.y, maxAngle), smoothValue);
        else
            tran.eulerAngles = Vector3.Lerp(tran.eulerAngles, new Vector3(tran.eulerAngles.x, tran.eulerAngles.y, minAngle), smoothValue);

    }
 
}
