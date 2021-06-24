using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Mirror;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

public class MyPlayerNetworkManager : NetworkBehaviour
{
	private LevelLoader levelLoader = new LevelLoader();
	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!isClientOnly)
			CmdSendLevelToHost(PlayerPrefs.GetString("selectedLevelName"));
		else
			RpcSendLevelToClientOnly(PlayerPrefs.GetString("selectedLevelName"));
	}
	[Command]
	public void CmdSendLevelToHost(string levelName)
	{
		if (isServerOnly)
			return;
		levelLoader.DeserializeGameObject(DeserializeLevel(levelName).levelData, null);
	}
	[ClientRpc]
	public void RpcSendLevelToClientOnly(string levelName)
	{
		if (!isClientOnly)
			return;
		levelLoader.DeserializeGameObject(DeserializeLevel(levelName).levelData, null);
	}

	private Level DeserializeLevel(string levelName)
	{
		string path = Application.persistentDataPath + "/" + levelName + ".level";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(path, FileMode.Open);
		Level lv = null;
		if (File.Exists(path))
		{
			lv = formatter.Deserialize(stream) as Level;
		}
		else
		{
			Debug.LogError("Sorry Level Not Found");
		}
		stream.Close();
		return lv;
	}

}