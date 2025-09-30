using Internal.Enums;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop Items")]
public class ShopItem : ScriptableObject
{
    public string itemName = "";
    public int maxItems = 1;
    public Sprite image;
    public int howMuch = 100;
    public ShopType shopType;
    public bool isBought = false;
    public bool isEquip = false;
    public bool isInv = false;
}
