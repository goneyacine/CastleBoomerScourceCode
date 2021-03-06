using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System;

public class LevelLoader : MonoBehaviour
{
    public List<Sprite> allSprites;
    public List<RuntimeAnimatorController> allControllers;
    public Transform mainParent;

    public void LoadLevel(string levelName)
    {
        Level level = DeserializeLevel(levelName);
        DeserializeGameObject(level.levelData, mainParent);
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

        GameObject myObject = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity, parent);
        myObject.name = serializableObject.name;
        foreach (SerializableComponent sComp in serializableObject.serializableComponents)
        {
            Type compType = sComp.componentType as Type;
            myObject.AddComponent(compType);
            for (int i = 0; i < sComp.propertiesNames.Count; i++) {
                try {
                    string pName = sComp.propertiesNames[i];
                    object loadPropertyValue = sComp.values[i];
                    var pValue = loadPropertyValue;
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
                        SerializableSprite sSprite = (SerializableSprite)loadPropertyValue;
                        foreach (Sprite sprite in allSprites)
                        {
                            myObject.GetComponent<SpriteRenderer>().sortingOrder = 31;
                            if (sprite.name.Equals(sSprite.spriteName))
                            {
                                myObject.GetComponent<SpriteRenderer>().sprite = sprite;
                                continue;
                            }
                        }
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

                    } else if (loadPropertyValue.GetType() == typeof(SerializableVector2[]))
                    {
                        SerializableVector2[] data = (SerializableVector2[])loadPropertyValue;
                        Vector2[] vectors = new Vector2[data.Length];
                        for (int x = 0; x < data.Length; x++)
                        {
                            SerializableVector2 sVector = data[x];
                            vectors[x] = new Vector2(sVector.x, sVector.y);
                        }
                        pValue = vectors;
                    }
                    else if (loadPropertyValue.GetType() == typeof(SerializableVector3[]))
                    {
                        SerializableVector3[] data = (SerializableVector3[])loadPropertyValue;
                        Vector3[] vectors = new Vector3[data.Length];
                        for (int x = 0; x < data.Length; x++)
                        {
                            SerializableVector3 sVector = data[x];
                            vectors[x] = new Vector3(sVector.x, sVector.y);
                        }
                        pValue = vectors;
                    } else if (loadPropertyValue.GetType() == typeof(SerializableAnimatorController))
                    {
                        SerializableAnimatorController sControlller = (SerializableAnimatorController)loadPropertyValue;
                        foreach (RuntimeAnimatorController controller in allControllers)
                        {
                            if (controller.name.Equals(sControlller.animatorControllerName))
                            {
                                myObject.GetComponent<Animator>().runtimeAnimatorController =  controller;
                                continue;
                            }
                        }
                    }

                    PropertyInfo pInfo = compType.GetProperty(pName);
                    pInfo.SetValue(myObject.GetComponent(compType), pValue);
                } catch (Exception e) {
                    Debug.LogWarning(e);
                }
            }
        }

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

        foreach (SerializableGameObject child in serializableObject.childs)
            DeserializeGameObject(child, myObject.transform);
    }
}

