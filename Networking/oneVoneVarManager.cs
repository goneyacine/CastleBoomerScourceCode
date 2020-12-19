using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class oneVoneVarManager : MonoBehaviour {

 public GameObject mapEditor;
 public GameObject oneVoneChoice;
 public GameObject errorPanel;
 public Text errorContent;
 //this is the castle that the other player made
 public GameObject castleParent = null;
 //this is the castle that this player made
 public GameObject myCastle;
 public GameObject gameplayWindowObject;
 public static oneVoneVarManager OneVoneVarManager;
 public List<Vector3> positions;
 public List<string> names;
 public List<float> zRotations;
 public oneVoneVarManager(){
  if(OneVoneVarManager == null)
  OneVoneVarManager = this;
  else if (OneVoneVarManager != this)
  Destroy(gameObject);
 }
}
