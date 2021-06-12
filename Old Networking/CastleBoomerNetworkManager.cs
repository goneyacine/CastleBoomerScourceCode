using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Mirror;
public class CastleBoomerNetworkManager : NetworkManager
{
    //when the player open the 1v1/join window start host
    public void Be_A_Host()
    {
        try{
        StartHost();
        Debug.Log("Host Started");
        }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
  }
    }
    public void Dont_Be_A_Host(){
        try{
        StopHost();
        Debug.Log("Host Stoped");
        }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
  }
    }
    public void Join()
    {
        //trying to connect to the target player host 
        try
        {
            networkAddress = ID_Generator.ID_to_IP(enterPlayerID.text);
            StartClient();
            Debug.Log("Client Started");
        
       }catch(Exception e){
    oneVoneVarManager.OneVoneVarManager.errorPanel.SetActive(true);
    oneVoneVarManager.OneVoneVarManager.errorContent.text = e.ToString();
  }
    }
    public InputField enterPlayerID;
}
