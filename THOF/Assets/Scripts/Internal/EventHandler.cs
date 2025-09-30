using System;

namespace Internal
{
    public static class EventHandler
    {
        public static Action OnEnterShop;

        public static void DispatchEnterShop() => OnEnterShop?.Invoke();
        
        public static Action OnExitShop;

        public static void DispatchExitShop() => OnExitShop?.Invoke();
    }
}