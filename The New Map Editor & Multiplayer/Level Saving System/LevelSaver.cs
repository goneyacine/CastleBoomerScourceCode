using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class LevelSaver : MonoBehaviour
{

    //this method is called when the player hits create new level button

    public void CreateNewLevel(InputField input)
    {

        //checking if there is a folder for the levels if there is not then create one
        if (!Directory.Exists(Application.persistentDataPath + "/Multiplayer Levels"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Multiplayer Levels");
        }
        
        string levelName = input.text;
        Level lv = new Level();
        lv.name = levelName;
        currentLevelName = levelName;
        string path = Application.persistentDataPath + "/Multiplayer Levels/" + levelName + ".level";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, lv);
        stream.Close();
        Debug.Log("Level Created");
    }
    public void OpenLevel(string levelName)
    { 
     currentLevelName = levelName;
     loader.LoadLevel(levelName);
    }

    public void SaveCurrentLevel(GameObject level)
    {
        //checking if there is a folder for the levels if there is not then create one
        if (!Directory.Exists(Application.persistentDataPath + "/Multiplayer Levels"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Multiplayer Levels");
        }
        if (currentLevelName != null)
        {
            Level lv = new Level();
            lv.name = currentLevelName;
            lv.SetLevel(level);
            string path = Application.persistentDataPath + "/Multiplayer Levels/" + currentLevelName + ".level";
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, lv);
            stream.Close();
            Debug.Log("Level Saved");
        }
    }

    //the name of the level that the player is editing
    private string currentLevelName;

    public LevelLoader loader;

}
