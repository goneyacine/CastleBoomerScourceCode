using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Mirror;

public class MyNetworkManager : NetworkManager
{
	//when the player open the 1v1/join window start host
	public void StartHost()
	{
		try {
			StartHost();
			Debug.Log("Host Started");
		} catch (Exception e) {
			Debug.LogError(e);
		}
	}
	public void StopHost() {
		try {
			StopHost();
			Debug.Log("Host Stoped");
		} catch (Exception e) {
			Debug.LogError(e);
		}
	}
	public void Join()
	{
		//trying to connect to the target player host
		try
		{
			networkAddress = ID_Generator.ID_to_IP(id);
			StartClient();
			Debug.Log("Client Started");

		} catch (Exception e) {
			Debug.Log(e);
		}
	}
	public string id;
	public bool isHost = false;
}