using System;
using Internal.Enums;

namespace Internal
{
    public static class EventHandler
    {
        public static Action<ShopType> OnEnterShop;

        public static void DispatchEnterShop(ShopType shopType) => OnEnterShop?.Invoke(shopType);
        
        public static Action OnExitShop;

        public static void DispatchExitShop() => OnExitShop?.Invoke();

        public static class Player
        {
            public static Action OnLevelUp;
            public static void DispatchLevelUp() => OnLevelUp?.Invoke();

            public static Action OnPlayerDead;
            public static void DispatchPlayerDead() => OnPlayerDead?.Invoke();

            public static Action<bool> OnPlayerEnterChest;
            public static void DispatchPlayerEnterChest(bool enter) => OnPlayerEnterChest?.Invoke(enter);
        }
    }
}