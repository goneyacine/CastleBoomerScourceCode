using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//NOTE : AN EDITOR OBJECT IS JUST A CASTLE OBJECT WITH SOME CHANGES 
public class Drag_Drop : MonoBehaviour
{
	private void Start()
	{

     OnChangeCastleObject();

	}
    public void InitEditorObject()
    {

    	GameObject newEditorObject = Instantiate(editorObjectPrefab,editorObjectStartPosition.position,Quaternion.identity,castleObjParent);
    	newEditorObject.GetComponent<Castle_Object_Manager>().castle_Object = castleObject;

    }
    //we call this function when we change the castle object 
    private void OnChangeCastleObject()
    {
    	if(castleObject == null)
    	 return;

    	icon.sprite = castleObject.icon;
    }
	public GameObject editorObjectPrefab;
	public Castle_Object castleObject;
	public Image icon;
	public Transform editorObjectStartPosition;
    public Transform castleObjParent;
}