using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI.Shop
{
    public class ShopItemUI : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private Button buyButton;

        private ShopItem _itemData;

        public void SetItemData(ShopItem shopItem)
        {
            _itemData = shopItem;
            itemImage.sprite = shopItem.image;
            itemName.SetText(shopItem.itemName);
        }

        public void BuyItem()
        {
            if (Stats.Instance.coins < _itemData.howMuch)
            {
                UIReferences.Instance.OpenWindow("No Coins", "Not enough money", 3);
                return;
            }

            buyButton.interactable = false;
            Stats.Instance.coins -= _itemData.howMuch;
            UIReferences.Instance.OpenWindow("Item Bought",$"Bought item {_itemData.itemName}", 3);
            InventoryUI.Instance.attack1.isBought = true;
            InventoryUI.Instance.CheckItems();
        }
    }
}