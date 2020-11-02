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
    private void OnEnable()
    {
        StartHost();
        Debug.Log("Host Started");
    }
    public void Join()
    {
        //stoping the host to join the target host 
        StopHost();
        Debug.Log("Host Stoped");
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
            StartHost();
            Debug.Log("Failed To Join With Target Player");
            Debug.Log("Host Started Again");
        }
    }
    public InputField enterPlayerID;
}
