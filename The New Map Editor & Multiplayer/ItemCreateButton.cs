using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCreateButton : MonoBehaviour
{
	public GameObject myObject;
	public Vector3 spawingPosition;
	public Transform parent;
	public void Spawn()
	{
     Instantiate(myObject,spawingPosition,Quaternion.identity,parent);
	}
}