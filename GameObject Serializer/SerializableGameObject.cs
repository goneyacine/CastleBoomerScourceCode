using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableGameObject 
{
 public SerializableGameObject(List<SerializableComponent> serializableComponents,List<List<float>> transformData,List<SerializableGameObject> childs)
 {
  this.serializableComponents = serializableComponents;
  this.transformData = transformData;
  this.childs = childs;
 }
 //the transform data list contains the position rotation & scale data
 public List<SerializableComponent> serializableComponents;
  public List<List<float>> transformData;
 public List<SerializableGameObject> childs;  
}

[System.Serializable]
public class SerializableComponent 
{
 public SerializableComponent(Type componentType,string xmlData)
 {
  this.componentType = componentType;
  this.xmlData = xmlData;
 }


 public Type componentType;
 public string xmlData;
}