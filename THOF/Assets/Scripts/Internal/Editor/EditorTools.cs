using System.IO;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Internal.Editor
{
    public static class EditorTools
    {
        [MenuItem("THOF/Delete Save Game")]
        static void DeleteGameSave()
        {
            string dataPath = Path.Combine(Application.persistentDataPath, "GameData.dat");

            if (!File.Exists(dataPath))
            {
                Debug.LogWarning("No game save data to delete!");
                return;
            }
        
            File.Delete(dataPath);
            Debug.Log("Game save data deleted successfully!");
        }
    }
}
#endif