using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using Newtonsoft.Json;

public class Level 
{
   public new string name = "New Level";
   public string levelJSONGameObjectData;

   public void SetLevel(GameObject level)
   {
    JSONGameObject levelJSONGameObject = level.ToJSONGameObject();
    levelJSONGameObjectData = JsonConvert.SerializeObject(levelJSONGameObject);
    Debug.Log("Level GameObject Converted To JSON File");
   }

   public GameObject GetLevel()
   {
    JSONGameObject jsonGameObject = JsonConvert.DeserializeObject<JSONGameObject>(levelJSONGameObjectData);
    return jsonGameObject.ToGameObject();
    Debug.Log("Level GameObject Deserialized From JSON File");
   }
}
