using UnityEngine;
using System.Collections;
using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerNetworkManager : NetworkBehaviour
{ 
    private void Start()
    {
     PlayingGameObjects = GameObject.FindWithTag("Hey");
     
     Test = GameObject.FindWithTag("Test");
    }
    public void OnConnectedToServer()
    {
        //when a client join the server we check if the server is full or no
        if (!isClientOnly) { return; }
        //if no send confirmation request to the server (host)
        CmdJoinConfirmation();
    }
    //we call this commad when a client want to join the server and play with you
    [Command]
    public void CmdJoinConfirmation()
    {
        if (!isClientOnly)
        {
            Debug.Log("Other Conected To You , Now You Can Play Togther");
            Test.SetActive(false);
            PlayingGameObjects.SetActive(true);
            LoadPlayingScene();
        }
    }
    //when two players join the game load the gameplay scene and this is the need function
    [ClientRpc]
    public void LoadPlayingScene()
    {
        if (!isClientOnly) { return; }
        Test.SetActive(false);
        PlayingGameObjects.SetActive(true);
    }

    private GameObject PlayingGameObjects;
    private GameObject Test;
}
