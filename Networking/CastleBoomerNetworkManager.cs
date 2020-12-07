using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Mirror;
public class CastleBoomerNetworkManager : NetworkManager
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    //when the player open the 1v1/join window start host
    public void Be_A_Host()
    {
        StartHost();
        Debug.Log("Host Started");
    }
    public void Dont_Be_A_Host(){
        StopHost();
        Debug.Log("Host Stoped");
    }
    public void Join()
    {
        //trying to connect to the target player host 
        try
        {
            networkAddress = ID_Generator.ID_to_IP(enterPlayerID.text);
            StartClient();
            Debug.Log("Client Started");
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            Debug.Log("Failed To Join With Target Player");
        }
    }
    public InputField enterPlayerID;
}
