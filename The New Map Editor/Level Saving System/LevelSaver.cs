using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class LevelSaver : MonoBehaviour
{
    
	//this method is called when the player hits create new level button

    public void CreateNewLevel(InputField input)
    {

     //checking if there is a folder for the levels if there is not then create one
     if(!Directory.Exists(Application.persistentDataPath + "/Multiplayer Levels"))
     {
     Directory.CreateDirectory(Application.persistentDataPath + "/Multiplayer Levels");
     }

     string levelName = input.text;
     Level lv = new Level();
     lv.name = levelName;
     lv.level = null;
     currentLevelName = levelName;
     System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Level));  
     FileStream file = File.Create(Application.persistentDataPath + "/Multiplayer Levels/" + levelName + ".xml");  
     writer.Serialize(file,lv);  
     file.Close();  
     Debug.Log("Level Created");
    }

    public void SaveCurrentLevel(GameObject level)
    {
        //checking if there is a folder for the levels if there is not then create one
        if(!Directory.Exists(Application.persistentDataPath + "/Multiplayer Levels"))
         {
           Directory.CreateDirectory(Application.persistentDataPath + "/Multiplayer Levels");
         }
    	if(currentLevelName != null)
    	{
         Level lv = new Level();
         lv.name = currentLevelName;
         lv.level = level;
         System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Level));  
         FileStream file = new FileStream(Application.persistentDataPath + "/Multiplayer Levels/" + currentLevelName + ".xml",FileMode.Open);  
         writer.Serialize(file,lv);  
         file.Close();  
         Debug.Log("Level Saved");
    	}
    }
    
    //the name of the level that the player is editing 
    private string currentLevelName;    

}
