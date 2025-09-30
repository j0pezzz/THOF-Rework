using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chest Items")]
public class ChestItems : ScriptableObject
{
    public string type;
    public int amount;
    public Sprite image;
    public bool inChest = false;
}
