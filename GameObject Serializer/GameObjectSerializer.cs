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
      foreach (PropertyInfo pInfo in comp.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
        try {
          //trying to store the component property data
          propertiesNames.Add(pInfo.Name);
          object pValue = pInfo.GetValue(targetObject.GetComponent(comp.GetType()));
          if (pValue.GetType() == typeof(Vector2))
            values.Add(new SerializableVector2((Vector2)pValue));
          else if (pValue.GetType() == typeof(Vector3))
            values.Add(new SerializableVector3((Vector3)pValue));
          else if (pValue.GetType() == typeof(Quaternion))
            values.Add(new SerializableQuaternion((Quaternion)pValue));
          else if (pValue.GetType() == typeof(Sprite))
            values.Add(new SerializableSprite((Sprite)pValue));
          else if (pValue.GetType() == typeof(Color))
            values.Add(new SerializableColor((Color)pValue));
          else if (pValue.GetType() == typeof(Vector4))
            values.Add(new SerializableVector4((Vector4)pValue));
          else if (pValue.GetType() == typeof(Bounds))
            values.Add(new SerializableBounds((Bounds)pValue));
          else if (pValue.GetType() == typeof(Matrix4x4))
             values.Add(new Serializable4x4Matrix((Matrix4x4)pValue));
            else
              values.Add(pValue);
        } catch (Exception e) {
          continue;
        }
      }
      sComp.propertiesNames = propertiesNames;
      sComp.values = values;
      Debug.Log("..." + sComp.ToString());
      serializableComponents.Add(sComp);
      Debug.Log("compoenent added seccesfully //..// count == " + serializableComponents.Count);
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

    SerializableGameObject sObject = new SerializableGameObject(serializableComponents, transformData, childs);

    return sObject;

  }
}

