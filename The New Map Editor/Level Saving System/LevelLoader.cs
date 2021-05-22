using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
   public void LoadLevel(string levelName)
   {
    Level level = DeserializeLevel(levelName);

   }

   public Level DeserializeLevel(string levelName)
   {

    string path = Application.persistentDataPath + "/Multiplayer Levels" + "/" + name + ".level";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        Level lv = null;
        if (File.Exists(path))
        {
           lv = formatter.Deserialize(stream) as object;
        }
        else
        {
            Debug.LogError("Sorry Level Not Found");
        }
        stream.Close();
        return lv;
    }
    public void DeserializeGameObject(SerializableGameObject serializableObject,Transform parent)
    {
     
     GameObject myObject;
     if(parent == null)
     myObject = Instantiate(new GameObject(),Vector3.zero,Quaternion.identity);
     else
     myObject = Instantiate(new GameObject(),Vector3.zero,Quaternion.identity,parent);
     
     myObject.transform.position = serializableObject.transformData[0];
     myObject.transform.eulerAngles = serializableObject.transformData[1];
     myObject.transform.localScale = serializableObject.transformData[2];

     foreach(SerializableComponent sComp in serializableComponents)
     {
     XmlSerializer serializer = new XmlSerializer(typeof(Component));
     var sw = new StringWriter();
     myObject.AddComponent(serializer.Deserialize(sw) as Component);
    }
    
  }
}

