using UnityEngine;
using System.IO;
using Internal.Structures.Save_System;
using System.Text;

public static class SaveSystem
{
    public static SaveData SaveData;
    
    public static void SavePlayer(Stats stats)
    {
        SaveData saveData = new()
        {
            Coins = stats.coins,
            Level = stats.level,
            Health = stats.health,
            Position = stats.transform.position,
        };
        
        string saveFile = JsonUtility.ToJson(saveData);

        byte[] saveFileBytes = Encoding.UTF8.GetBytes(saveFile);

        if (saveFileBytes.Length <= 0)
        {
            Debug.LogError("Nothing to save!");
            return;
        }
            
        string dataPath = Path.Combine(Application.persistentDataPath, "GameData.dat");
        
        File.WriteAllBytes(dataPath, saveFileBytes);
        
        Debug.Log($"Saved save file to: {dataPath}");
    }


    public static bool LoadPlayer()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "GameData.dat");

        if (!File.Exists(dataPath))
        {
            Debug.Log("No save data available!");
            return false;
        }
        
        byte[] saveFileBytes = File.ReadAllBytes(dataPath);

        if (saveFileBytes.Length <= 0)
        {
            Debug.LogWarning("No save data!");
            return false;
        }
        
        string saveFile = Encoding.UTF8.GetString(saveFileBytes);
            
        SaveData = JsonUtility.FromJson<SaveData>(saveFile);

        Debug.Log("Loaded save data!");
        return true;
    }
}
