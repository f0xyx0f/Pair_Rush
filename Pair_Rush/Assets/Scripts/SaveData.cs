using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData
{
    public static int[] ActiveLevels;
    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        Data data = new Data();
        data.ActiveLevels = ActiveLevels;
        bf.Serialize(file, data);
        file.Close();
    }
    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();
            ActiveLevels = data.ActiveLevels;
            Debug.Log("Game data loaded!");
        }
        else
        {
            ActiveLevels = new int[9];
            for (int i = 1; i < 9; ++i)
                ActiveLevels[i] = 0;
            ActiveLevels[0] = 1;
        }
    }
    public static void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
        }
    }
}

[Serializable]
class Data
{
    public int[] ActiveLevels;
}
