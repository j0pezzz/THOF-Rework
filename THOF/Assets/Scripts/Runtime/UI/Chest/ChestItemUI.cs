using Internal.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI.Chest
{
    public class ChestItemUI : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI itemName;

        private ChestItem _cacheItem;

        public void InitializeItem(ChestItem item)
        {
            _cacheItem = item;
            itemIcon.sprite = item.image;
            itemName.SetText(item.identifier.ToUpperInvariant());
        }

        public void TakeItem()
        {
            switch (_cacheItem.type)
            {
                case ChestItemType.Coins:
                    Stats.Instance.AddCoins(_cacheItem.amount);
                    ChestUI.Instance.RemoveChestItem(_cacheItem.identifier);
                    //TODO: implement a notification for getting *amount* of coins.
                    break;
                case ChestItemType.Weapon:
                    //TODO: implement weapon pick up
                    break;
            }
        }
    }
}