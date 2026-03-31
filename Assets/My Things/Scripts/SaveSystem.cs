using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveLevels(LevelData lvlData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levelData.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(lvlData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadLevels()
    {
        string path = Application.persistentDataPath + "/levelData.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
