using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Internal/Game Data", fileName = "Game Data")]
public class GameData : ScriptableObject
{
    //TODO: we need a proper Input handling script.
    public InputActionAsset inputActions;
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
}
