using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Internal/Game Data", fileName = "Game Data")]
public class GameData : ScriptableObject
{
    public List<ShopItem> shopItems;
    public List<ShopItem> startingItems;

    private static GameData _instance;

    public static GameData Instance
    {
        get
        {
            if (!_instance) _instance = Resources.Load("Game Data") as GameData;
            return _instance;
        }
    }

#if UNITY_EDITOR
    [MenuItem("THOF/Delete Save Game")]
    static void DeleteGameSave()
    {
        string dataPath = Path.Combine(Application.persistentDataPath, "GameData.dat");

        if (!File.Exists(dataPath))
        {
            Debug.Log("No save data to delete!");
            return;
        }
        
        File.Delete(dataPath);
        Debug.Log("Save Game deleted successfully!");
    }
#endif
}
