using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBoomerMap : MonoBehaviour {
	public GameObject castleObjectsParent;
     public CastleBoomerMap(GameObject castleObjectsParent)
     {
      this.castleObjectsParent = castleObjectsParent;
      Debug.Log("Castle Boomer Map Saved");
     }
}