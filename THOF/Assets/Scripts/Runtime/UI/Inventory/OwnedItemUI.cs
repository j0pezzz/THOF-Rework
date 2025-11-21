using UnityEngine;
using UnityEngine.UI;

public class OwnedItemUI : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    private ShopItem _cacheItem;
    
    public void SetItemData(ShopItem item)
    {
        _cacheItem = item;
        itemImage.sprite = item.image;
    }

    public void EquipItem()
    {
        //TODO: need to add a "slot" where the weapon goes, for now it will be 2 for all.
        Stats.Instance.equippedItems[2] = _cacheItem;
        UIReferences.Instance.ShowWeaponEquip($"EQUIPPED {_cacheItem.itemName}");
    }
}
