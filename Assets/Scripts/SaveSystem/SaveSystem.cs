using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void saveData<T>(T data, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/" + fileName;

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    public static T loadData<T>(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;

        if (!File.Exists(path))
        {
            Debug.LogError("Save file does not exist in " + path);
            return default;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            return (T)formatter.Deserialize(stream);
        }
    }
}