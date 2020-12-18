using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStarter : MonoBehaviour{
	public Vector3 mapPosition;
	private void OnEnable(){
     GameObject castle = Instantiate(oneVoneVarManager.OneVoneVarManager.castleParent,mapPosition,Quaternion.identity,transform);
	}
}