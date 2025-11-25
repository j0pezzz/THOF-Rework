using Internal.Enums;
using UnityEngine;

[CreateAssetMenu(menuName = "Chest Items")]
public class ChestItem : ScriptableObject
{
    public string identifier;
    public ChestItemType type;
    public int amount;
    public Sprite image;
    public bool inChest = false;
}
