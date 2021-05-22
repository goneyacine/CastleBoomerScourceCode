using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class GameObjectSerializer : MonoBehaviour
{

   public static void SerializeGameObject(GameObject targetObject,string path)
   {  
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream,ToSerializableGameObject(targetObject));
        stream.Close();
   }

   public static SerializableGameObject ToSerializableGameObject(GameObject targetObject)
   {

     Component[] allComponents;
     allComponents = targetObject.GetComponents<Component>(); 

     List<SerializableComponent> serializableComponents = new List<SerializableComponent>();

     foreach(Component comp in allComponents)
     {  
     	try { 
     	serializableComponents.Add(ToSerializableComponent(comp));
	    }catch(Exception e){
         continue;
	    }
     }
     
     List<SerializableGameObject> childs = new List<SerializableGameObject>();

     foreach(Transform child in targetObject.transform)
     childs.Add(ToSerializableGameObject(child.gameObject));
       
      List<float> position = new List<float>();
    position.Add(targetObject.transform.position.x);
    position.Add(targetObject.transform.position.y);
    position.Add(targetObject.transform.position.z);

    List<float> rotation = new List<float>();
    rotation.Add(targetObject.transform.eulerAngles.x);
    rotation.Add(targetObject.transform.eulerAngles.y);
    rotation.Add(targetObject.transform.eulerAngles.z);

    List<float> scale = new List<float>();
    scale.Add(targetObject.transform.localScale.x);
    scale.Add(targetObject.transform.localScale.y);
    scale.Add(targetObject.transform.localScale.z);

    List<List<float>> transformData = new List<List<float>>();
    transformData.Add(position);
    transformData.Add(rotation);
    transformData.Add(scale);

    SerializableGameObject sObject = new SerializableGameObject(serializableComponents,transformData,childs);

     return sObject;

   }
   public static SerializableComponent ToSerializableComponent(Component comp)
   {

    XmlSerializer serializer = new XmlSerializer(typeof(Component));
    var sw = new StringWriter();
    serializer.Serialize(sw,comp);
    string xmlData = sw.ToString();
    return new SerializableComponent(comp.GetType(),xmlData);
       
   }
}

