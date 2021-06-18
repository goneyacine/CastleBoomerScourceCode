using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BodyTypeManager : MonoBehaviour
{
	public bool isStatic = false;

	private void OnEnable()
	{
	 if(isStatic == false || SceneManager.GetActiveScene().name == "Map Editor")
     gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
     else 
     gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

	}
}