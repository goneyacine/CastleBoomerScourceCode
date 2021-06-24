using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameStarter : MonoBehaviour
{
	public void OnEnable()
	{
		if (starter == null)
			starter = this;
		else if (starter != this && starter != null)
			Destroy(gameObject);
        
		networkManager.id = PlayerPrefs.GetString("otherPlayerID");
		if (PlayerPrefs.GetInt("isHost") == 0)
			networkManager.StartHost();
		else
			networkManager.Join();

	}
	public Transform levelMainParent;
	public LevelLoader levelLoader;
	public static GameStarter starter;
	public MyNetworkManager networkManager;
}