using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStarter : MonoBehaviour{
	public static MapStarter mapStarter;
	public GameObject castleObjectPrefab;
	public List<Castle_Object> castleObjScriptableObjects;
	public Transform castle;
	public MapStarter(){
		if(mapStarter == null)
		mapStarter = this;
		else if (mapStarter != null && mapStarter != this)
		Destroy(gameObject);
	}
	public void SetUpMap(){
     for(int i = 0; i < oneVoneVarManager.OneVoneVarManager.names.Count;i++){
     GameObject castleObject = Instantiate(castleObjectPrefab,oneVoneVarManager.OneVoneVarManager.positions[i],
     Quaternion.identity,castle);
     castleObject.transform.eulerAngles = new Vector3(0,0,oneVoneVarManager.OneVoneVarManager.zRotations[i]);
     foreach(Castle_Object co in castleObjScriptableObjects){
     if(co.name == oneVoneVarManager.OneVoneVarManager.names[i]){
     castleObject.GetComponent<Castle_Object_Manager>().castle_Object = co;
     break;
          }
     }
     Debug.Log("map started");
     }
	}
}