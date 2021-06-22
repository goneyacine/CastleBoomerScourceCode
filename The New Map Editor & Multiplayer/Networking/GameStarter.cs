using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameStarter : MonoBehaviour
{
	public void Start()
	{
		if (starter == null)
			starter = this;
		else
			Destroy(gameObject);
        selectedLevelData = PlayerPrefs.GetString("selectedLevelData");
		networkManager.id = PlayerPrefs.GetString("otherPlayerID");
		if (PlayerPrefs.GetInt("isHost") == 0)
			networkManager.StartHost();
		else
			networkManager.Join();

	}
	public void LoadLevel(string levelData)
	{
		FileStream file = new FileStream(Application.persistentDataPath + "level.level",FileMode.Create);
		StreamWriter writer = new StreamWriter(file);
		writer.Write(levelData);
		writer.Close();
		BinaryFormatter formatter = new BinaryFormatter();
		Level level = formatter.Deserialize(file) as Level;
		levelLoader.DeserializeGameObject(level.levelData, levelMainParent);
	}
	public Transform levelMainParent;
	public LevelLoader levelLoader;
	public static GameStarter starter;
	public string selectedLevelData;
	public MyNetworkManager networkManager;
}