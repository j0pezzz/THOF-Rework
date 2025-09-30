using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Internal/Game Data", fileName = "Game Data")]
public class GameData : ScriptableObject
{
    public List<ShopItem> shopItems;

    private static GameData _instance;

    public static GameData Instance
    {
        get
        {
            if (!_instance) _instance = Resources.Load("Game Data") as GameData;
            return _instance;
        }
    }
}
