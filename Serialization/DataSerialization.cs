using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class DataSerialization 
{
    public static void SaveData(object obj,string name)
    {
        string path = Application.persistentDataPath + "/" + name +".txt" ;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream,obj);
        stream.Close();
    }
    public static object GetObject(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".txt";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        object obj = null;
        if (File.Exists(path))
        {
           obj =  formatter.Deserialize(stream) as object;
        }
        else
        {
            Debug.LogError("We Can't Find File With Name : " + name);
        }
        stream.Close();
        return obj;
    }
    public static bool fileExists(string path)
    {
        bool exists = false;
        if (File.Exists(path))
            exists = true;
        else
            exists = false;
        return exists;
    }
}
