using Internal.Enums;
using UnityEngine;
using EventHandler = Internal.EventHandler;

namespace Runtime
{
    public class Shop : MonoBehaviour
    {
        public ShopType shopType = ShopType.Shop1;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            EventHandler.DispatchEnterShop(shopType);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            EventHandler.DispatchExitShop();
        }
    }
}