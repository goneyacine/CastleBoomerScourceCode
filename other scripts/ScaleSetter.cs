using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSetter : MonoBehaviour
{
	public Transform parent;
    public Transform child;
    public Vector3 scale = Vector3.one;
    private Vector3 parentScale;
    private void Awake(){
    parentScale = parent.localScale;
    }
    private void Update(){
    transform.localScale = new Vector3(scale.x / parent.localScale.x,
     scale.y / parent.localScale.y);
     child.eulerAngles = Vector3.zero;
    }
}
