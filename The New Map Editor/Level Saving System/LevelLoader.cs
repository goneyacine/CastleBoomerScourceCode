using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System;

public class LevelLoader : MonoBehaviour
{

    public void LoadLevel(string levelName)
    {
        Level level = DeserializeLevel(levelName);
        DeserializeGameObject(level.levelData, null);
    }

    public Level DeserializeLevel(string levelName)
    {

        string path = Application.persistentDataPath + "/Multiplayer Levels" + "/" +  levelName + ".level";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        Level lv = null;
        if (File.Exists(path))
        {
            lv = formatter.Deserialize(stream) as Level;
        }
        else
        {
            Debug.LogError("Sorry Level Not Found");
        }
        stream.Close();
        return lv;
    }
    public void DeserializeGameObject(SerializableGameObject serializableObject, Transform parent)
    {

        GameObject myObject;
        if (parent == null)
            myObject = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
        else
            myObject = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity, parent);
        Vector3 position = new Vector3();
        position.x = serializableObject.transformData[0][0];
        position.y = serializableObject.transformData[0][1];
        position.z = serializableObject.transformData[0][2];
        Vector3 rotation = new Vector3();
        rotation.x = serializableObject.transformData[1][0];
        rotation.y = serializableObject.transformData[1][1];
        rotation.z = serializableObject.transformData[1][2];
        Vector3 scale = new Vector3();
        scale.x = serializableObject.transformData[2][0];
        scale.y = serializableObject.transformData[2][1];
        scale.z = serializableObject.transformData[2][2];

        myObject.transform.position = position;
        myObject.transform.eulerAngles = rotation;
        myObject.transform.localScale = scale;

        foreach (SerializableComponent sComp in serializableObject.serializableComponents)
        {
            Type compType = sComp.componentType as Type;
            myObject.AddComponent(compType);
            for (int i = 0; i < sComp.propertiesNames.Count; i++) {
                string pName = sComp.propertiesNames[i];
                object loadPropertyValue = sComp.values[i];
                object pValue;
                if (loadPropertyValue.GetType() == typeof(SerializableVector2))
                {
                    SerializableVector2 vector = (SerializableVector2)loadPropertyValue;
                    pValue = new Vector2(vector.x, vector.y);
                }
                else if (loadPropertyValue.GetType() == typeof(SerializableVector3))
                {
                    SerializableVector3 vector = (SerializableVector3)loadPropertyValue;
                    pValue = new Vector3(vector.x, vector.y, vector.z);
                } else if (loadPropertyValue.GetType() == typeof(SerializableQuaternion))
                {
                    SerializableQuaternion quat = (SerializableQuaternion)loadPropertyValue;
                    pValue = new Quaternion(quat.x, quat.y, quat.z, quat.w);
                } else if (loadPropertyValue.GetType() == typeof(SerializableSprite))
                {
                    SerializableSprite sSprite =  (SerializableSprite)loadPropertyValue;
                    Texture2D tex = new Texture2D(sSprite.width, sSprite.height);
                    ImageConversion.LoadImage(tex, sSprite.data);
                    pValue = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one);
                } else if (loadPropertyValue.GetType() == typeof(SerializableColor))
                {
                    SerializableColor sColor = (SerializableColor)loadPropertyValue;
                    pValue = new Color(sColor.r, sColor.g, sColor.b, sColor.a);
                } else if (loadPropertyValue.GetType() == typeof(SerializableVector4))
                {
                    SerializableVector4 sVector = (SerializableVector4)loadPropertyValue;
                    pValue = new Vector4(sVector.x, sVector.y, sVector.z, sVector.w);
                } else if (loadPropertyValue.GetType() == typeof(SerializableBounds))
                {
                    SerializableBounds sBounds =  (SerializableBounds)loadPropertyValue;
                    pValue = new Bounds(new Vector3(sBounds.center[0], sBounds.center[1], sBounds.center[2])
                                        , new Vector3(sBounds.size[0], sBounds.size[1], sBounds.size[2]));
                } else if (loadPropertyValue.GetType() == typeof(Serializable4x4Matrix))
                {
                    Serializable4x4Matrix sMatrix = (Serializable4x4Matrix)loadPropertyValue;
                    Matrix4x4 matrix =  new Matrix4x4();

                    //setting up the matrix values

                    matrix[0, 0] = sMatrix.data[0, 0];
                    matrix[0, 1] = sMatrix.data[0, 1];
                    matrix[0, 2] = sMatrix.data[0, 2];
                    matrix[0, 3] = sMatrix.data[0, 3];


                    matrix[1, 0] = sMatrix.data[1, 0];
                    matrix[1, 1] = sMatrix.data[1, 1];
                    matrix[1, 2] = sMatrix.data[1, 2];
                    matrix[1, 3] = sMatrix.data[1, 3];


                    matrix[2, 0] = sMatrix.data[2, 0];
                    matrix[2, 1] = sMatrix.data[2, 1];
                    matrix[2, 2] = sMatrix.data[2, 2];
                    matrix[2, 3] = sMatrix.data[2, 3];

                    matrix[3, 0] = sMatrix.data[3, 0];
                    matrix[3, 1] = sMatrix.data[3, 1];
                    matrix[3, 2] = sMatrix.data[3, 2];
                    matrix[3, 3] = sMatrix.data[3, 3];

                    pValue = matrix;

                }
                else
                    pValue = loadPropertyValue;


                Debug.Log(pName + " = " + pValue);
                myObject.GetComponent(compType).GetType().GetProperty(pName, BindingFlags.Public | BindingFlags.Instance).SetValue(null, pValue);
            }
        }

        foreach (SerializableGameObject child in serializableObject.childs)
            DeserializeGameObject(child, myObject.transform);
    }
}

