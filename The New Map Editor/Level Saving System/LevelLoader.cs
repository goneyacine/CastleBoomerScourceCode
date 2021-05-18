using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
   public void LoadLevel(string levelName)
   {
   	Level lv = (Level)DataSerialization.GetObject("Multiplayer Levels/" + levelName);
   	Instantiate(lv.level,Vector2.zero,Quaternion.identity);
   }
}
