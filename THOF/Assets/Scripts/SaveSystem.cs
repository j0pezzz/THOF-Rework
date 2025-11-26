using UnityEngine;
using System.IO;
using Internal.Structures.Save_System;
using System.Text;

public class SaveSystem : MonoBehaviour
{
    public static SaveData SaveData;

    void Start()
    {
        DontDestroyOnLoad(this);
        LoadSaveGame();
    }

    public static void SaveGame(Stats stats)
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
        
        Debug.Log($"Saved game to: {dataPath}");
    }
    
    public static bool LoadSaveGame()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "GameData.dat");

        if (!File.Exists(dataPath)) return false;
        
        byte[] saveFileBytes = File.ReadAllBytes(dataPath);

        if (saveFileBytes.Length <= 0)
        {
            Debug.LogWarning("No game save available!");
            return false;
        }
        
        string saveFile = Encoding.UTF8.GetString(saveFileBytes);
            
        SaveData = JsonUtility.FromJson<SaveData>(saveFile);

        Debug.Log("Loaded save game!");
        return true;
    }
}
