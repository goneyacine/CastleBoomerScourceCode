using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSetter : MonoBehaviour
{
	public Transform parent;
    public Vector3 scale = Vector3.one;
    private void Start()
    {
     transform.localScale = new Vector3 ((scale.x / parent.localScale.x ) 
     	,(scale.y / parent.localScale.y) ,1f);   
    }
    private void Update(){
     transform.eulerAngles = Vector3.zero;
    }
}
