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

        //TODO: implement ability to take the item from the chest
        public void TakeItem()
        {
            
        }
    }
}