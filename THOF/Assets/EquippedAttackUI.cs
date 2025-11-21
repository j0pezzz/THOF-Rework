using UnityEngine;
using UnityEngine.UI;

public class EquippedAttackUI : MonoBehaviour
{
    //TODO: we need to add a method that will show attack information
    [SerializeField] private Image itemIcon;

    private ShopItem _cacheItem;
    
    public void SetItemData(ShopItem item)
    {
        _cacheItem = item;
        itemIcon.sprite = item.image;
    }
}
