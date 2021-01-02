using UnityEngine;
using System.Collections;
using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerNetworkManager : NetworkBehaviour
{ 
   private void Update(){
    try{
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
     oneVoneVarManager.OneVoneVarManager.WaitingPanel.SetActive(true);
     SaveCastle(oneVoneVarManager.OneVoneVarManager.myCastle);
     if(isServer)
     castleSentFromHostToClient = true;
     mapSaved = true;
    }
   }
   //check if the local gameIsDone
   if(localGameDone == false ){
    if(oneVoneVarManager.OneVoneVarManager.localGameDone){
      if(isServer)  
      localGameDone = true;
      else
      CmdGameDoneOnClientOnly();
     }
    }
    if(clientGameDone && localGameDone){
      oneVoneVarManager.OneVoneVarManager.gameDone = true;
      RpcGameDone();
    }
   }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
  
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
    try{
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
     }catch(Exception e){
      oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
     }
 }
   //we call this commad on client (onlyClient not a host) to send his map to the host
   [Command]
   void CmdSendCastleFromClientToHost(List<string> names,List<Vector3> positions,List<float> zRotations){
    try{
   if(!isServer)
    return;
    oneVoneVarManager.OneVoneVarManager.positions = positions;
    oneVoneVarManager.OneVoneVarManager.names = names;
    oneVoneVarManager.OneVoneVarManager.zRotations = zRotations;
    castleSentFromClientToHost = true;
    Debug.Log("castle sent from client to host");
    }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
    }
   }
   //we call this ClientRpc on the host to his map to client(onlyClient)
   [ClientRpc]
   void RpcSendCastleFromHostToClient(List<string> names,List<Vector3> positions,List<float> zRotations){
    try{
    if(isServer)
     return;
  oneVoneVarManager.OneVoneVarManager.positions = positions;
  oneVoneVarManager.OneVoneVarManager.names = names;  
  oneVoneVarManager.OneVoneVarManager.zRotations = zRotations;  
   Debug.Log("castle sent from host to client"); 
   }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
   }
   }
   //this clientRpc is to enable the gameplay tools on the client
   [ClientRpc]
   void RpcStartGameOnClient(){
    try{
    if(isServer)
    return;
     oneVoneVarManager.OneVoneVarManager.mapEditor.SetActive(false);
     oneVoneVarManager.OneVoneVarManager.gameplayWindowObject.SetActive(true);
     }catch(Exception e){
      oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
     }
   }
   [Command]
   void CmdGameDoneOnClientOnly(){
    if(!isServer)
    return;
    clientGameDone = true;
   }
   [ClientRpc]
   void RpcGameDone(){
    if(isServer)
    return;
    oneVoneVarManager.OneVoneVarManager.gameDone = true;
   }
   private bool castleSentFromClientToHost = false;
   private bool castleSentFromHostToClient = false;
   private bool mapSaved = false;
   private bool gameStarted = false;
   private bool localGameDone;
   public bool clientGameDone;
  }

