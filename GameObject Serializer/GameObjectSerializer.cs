using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

public class GameObjectSerializer
{

  public void SerializeGameObject(GameObject targetObject, string path)
  {
    BinaryFormatter formatter = new BinaryFormatter();
    FileStream stream = new FileStream(path, FileMode.Create);
    formatter.Serialize(stream, ToSerializableGameObject(targetObject));
    stream.Close();
  }

  public SerializableGameObject ToSerializableGameObject(GameObject targetObject)
  {

    Component[] allComponents;
    allComponents = targetObject.GetComponents(typeof(Component));

    List<SerializableComponent> serializableComponents = new List<SerializableComponent>();
    foreach (Component comp in allComponents)
    {
      if (comp.GetType() == typeof(Transform))
        continue;

      SerializableComponent sComp = new SerializableComponent(comp.GetType(), null, null);
      List<string> propertiesNames = new List<string>();
      List<object> values = new List<object>();
      foreach (PropertyInfo pInfo in comp.GetType().GetProperties()) {
        try {
          //trying to store the component property data
          object pValue = pInfo.GetValue(targetObject.GetComponent(comp.GetType()));

          if (pValue.GetType() == typeof(Vector2))
            pValue = new SerializableVector2((Vector2)pValue);
          else if (pValue.GetType() == typeof(Vector3))
            pValue = new SerializableVector3((Vector3)pValue);
          else if (pValue.GetType() == typeof(Quaternion))
            pValue = new SerializableQuaternion((Quaternion)pValue);
          else if (pValue.GetType() == typeof(Sprite))
            pValue = new SerializableSprite((Sprite)pValue);
          else if (pValue.GetType() == typeof(Color))
            pValue = new SerializableColor((Color)pValue);
          else if (pValue.GetType() == typeof(Vector4))
            pValue = new SerializableVector4((Vector4)pValue);
          else if (pValue.GetType() == typeof(Bounds))
            pValue = new SerializableBounds((Bounds)pValue);
          else if (pValue.GetType() == typeof(Matrix4x4))
            pValue = new Serializable4x4Matrix((Matrix4x4)pValue);
          else if (pValue.GetType() == typeof(Vector2[]))
          {
            Vector2[] data = (Vector2[])pValue;
            SerializableVector2[] vectors =  new SerializableVector2[data.Length];
            for (int i = 0; i < data.Length; i++)
            vectors[i] = new SerializableVector2(data[i]);
            pValue = vectors;
          }
          else if (pValue.GetType() == typeof(Vector3[]))
          {
              Vector3[] data = (Vector3[])pValue;
            SerializableVector3[] vectors =  new SerializableVector3[data.Length];
            for (int i = 0; i < data.Length; i++)
              vectors[i] = new SerializableVector3(data[i]);

            pValue = vectors;
          }else if(pValue.GetType() == typeof(RuntimeAnimatorController))
           pValue = new SerializableAnimatorController((RuntimeAnimatorController)pValue);
          else if (!(pValue.GetType().IsSerializable) || !(pValue.GetType().IsArray && pValue.GetType().GetElementType().IsSerializable))
            continue;

          values.Add(pValue);
          propertiesNames.Add(pInfo.Name);
        } catch (Exception e) {
          continue;
        }
      }
      sComp.propertiesNames = propertiesNames;


      foreach (object obj in values)
      {
        if (obj.GetType().IsSerializable == false) {
          values.Remove(obj);
          propertiesNames.Remove(propertiesNames[values.IndexOf(obj)]);
        }
        Debug.Log(".............." + obj.GetType() + "..............");
      }

      sComp.values = values;
      serializableComponents.Add(sComp);
    }

    List<SerializableGameObject> childs = new List<SerializableGameObject>();

    foreach (Transform child in targetObject.transform)
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

    SerializableGameObject sObject = new SerializableGameObject(targetObject.name,serializableComponents, transformData, childs);

    return sObject;

  }
}

