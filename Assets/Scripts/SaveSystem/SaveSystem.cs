using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (playerScript player, float timeLeft)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.carry";
        Debug.Log("Save File location: " + path);
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, timeLeft);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.carry";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save File not found" + path);
            return null;
        }
    }
}
