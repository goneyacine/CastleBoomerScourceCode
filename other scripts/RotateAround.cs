using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
   public float rotatingSpeed = 1f;
   private void FixedUpdate(){
   transform.eulerAngles += Vector3.forward * rotatingSpeed;
   }
}
