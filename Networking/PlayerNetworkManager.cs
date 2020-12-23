using UnityEngine;
using System.Collections;
using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerNetworkManager : NetworkBehaviour
{ 
   private void Update(){
    //if the game doesn't start yet 
    if(gameStarted == false){
      //we check if we can start the game if all the maps are saved
    if(isServer && castleSentFromHostToClient && castleSentFromClientToHost){
      MapStarter.mapStarter.SetUpMap();
      oneVoneVarManager.OneVoneVarManager.mapEditor.SetActive(false);
      oneVoneVarManager.OneVoneVarManager.gameplayWindowObject.SetActive(true);
      RpcStartGameOnClient();
      gameStarted = true;
    }

    //if the user pressed space and his map is not saved we save the map
    if(Input.GetKeyDown(KeyCode.Space) && !mapSaved){
     SaveCastle(oneVoneVarManager.OneVoneVarManager.myCastle);
     if(isServer)
     castleSentFromHostToClient = true;
     mapSaved = true;
    }
   }
  }
  //here when the second player join the game we try to enable the map editor on player 1 and 2 devices
   public override void OnStartClient(){
    base.OnStartClient();
    if(isServer)
    return;
  try{
   oneVoneVarManager.OneVoneVarManager.mapEditor.SetActive(true);
   oneVoneVarManager.OneVoneVarManager.oneVoneChoice.SetActive(false);
  CmdStartMapEditor();
  }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
  }
    }
    //this command starts the map editor on the host only
   [Command]
   void CmdStartMapEditor(){
    if(!isServer)
       return;
    try{
    oneVoneVarManager.OneVoneVarManager.mapEditor.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.oneVoneChoice.SetActive(false);
    }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
  }
}
 //we call this function when one of the two player press space to save the map and continue
  public void SaveCastle(GameObject castleParent){
    List<Vector3> positions = new List<Vector3>();
    List<string> names = new List<string>();
    List<float> zRotations = new List<float>();
    foreach (Transform editorTransform in castleParent.transform){
     positions.Add(editorTransform.position);
     names.Add(editorTransform.gameObject.GetComponent<Castle_Object_Manager>().castle_Object.name);
     zRotations.Add(editorTransform.eulerAngles.z);
    }
    if(!isServer){
      CmdSendCastleFromClientToHost(names,positions,zRotations);
    }else{
      RpcSendCastleFromHostToClient(names,positions,zRotations);
    }
   }
   //we call this commad on client (onlyClient not a host) to send his map to the host
   [Command]
   void CmdSendCastleFromClientToHost(List<string> names,List<Vector3> positions,List<float> zRotations){
   if(!isServer)
    return;
    oneVoneVarManager.OneVoneVarManager.positions = positions;
    oneVoneVarManager.OneVoneVarManager.names = names;
    oneVoneVarManager.OneVoneVarManager.zRotations = zRotations;
    castleSentFromClientToHost = true;
    Debug.Log("castle sent from client to host");
   }
   //we call this ClientRpc on the host to his map to client(onlyClient)
   [ClientRpc]
   void RpcSendCastleFromHostToClient(List<string> names,List<Vector3> positions,List<float> zRotations){
    if(isServer)
     return;
  oneVoneVarManager.OneVoneVarManager.positions = positions;
  oneVoneVarManager.OneVoneVarManager.names = names;  
  oneVoneVarManager.OneVoneVarManager.zRotations = zRotations;  
   Debug.Log("castle sent from host to client"); 
   }
   //this clientRpc is to enable the gameplay tools on the client
   [ClientRpc]
   void RpcStartGameOnClient(){
    if(isServer)
    return;
     oneVoneVarManager.OneVoneVarManager.mapEditor.SetActive(false);
     oneVoneVarManager.OneVoneVarManager.gameplayWindowObject.SetActive(true);
   }
   private bool castleSentFromClientToHost = false;
   private bool castleSentFromHostToClient = false;
   private bool mapSaved = false;
   private bool gameStarted = false;

  }

