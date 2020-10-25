using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Mirror;
public class CastleBoomerNetworkManager : NetworkManager
{
    private void OnEnable()
    {
        StartHost();
        Debug.Log("Host Started");
    }
    public void Join()
    {
        StopHost();
        Debug.Log("Host Stoped");
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
