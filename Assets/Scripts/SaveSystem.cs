using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {

    public static void SaveGameData(LevelCompleted level)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.progress";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(level);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGameData()
    {
        string path = Application.persistentDataPath + "/game.progress";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        } else
        {
            Debug.Log("save file not found in " + path);
            return null;
        }
    }

    public static void DeleteGameData()
    {
        string path = Application.persistentDataPath + "/game.progress";
        try
        {
            File.Delete(path);
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}

