using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class PlayLevelSelecter : MonoBehaviour
{
	private void OnEnable()
	{
		levels = new List<Level>();
		string[] filePaths = Directory.GetFiles(Application.persistentDataPath + "/Multiplayer Levels/", "*.level");
		BinaryFormatter formatter = new BinaryFormatter();

		foreach (string path in filePaths)
		{
			FileStream stream = new FileStream(path, FileMode.Open);
			levels.Add(formatter.Deserialize(stream) as Level);
			stream.Close();
		}
		ReloadUI();
	}
	public void Select(int index)
	{
		Level targetLevel = levels[index + startingIndex];
		FileStream file = new FileStream(Application.persistentDataPath + "/Multiplayer Levels" + "/" +  targetLevel.name + ".level", FileMode.Open);
		StreamReader reader = new StreamReader(file);
		string ln;
		string levelData = "";
		while ((ln = reader.ReadLine()) != null) {
		   levelData += ln;
		}
		PlayerPrefs.SetString("selectedLevelData", levelData);
	}
	public void ReloadUI()
	{

		for (int i = 0; i <= 3; i++)
		{
			if (startingIndex + i >= levels.Count)
			{
				levelPanels[i].parent.SetActive(false);
				continue;
			}
			else
			{
				levelPanels[i].parent.SetActive(true);
				levelPanels[i].levelNameText.text = levels[i].name;
			}
		}
	}
	public void UpdateStartingIndex(int updateValue)
	{
		if (startingIndex + updateValue >= 0 && startingIndex + updateValue < levels.Count)
			startingIndex += updateValue;
		else if (startingIndex + updateValue < 0)
			startingIndex = 0;
		else if (startingIndex + updateValue >= levels.Count)
			startingIndex = levels.Count - 1;

		ReloadUI();
	}
	public List<Level> levels = new List<Level>();
	public int startingIndex = 0;
	public List<LevelPanel> levelPanels;
}
