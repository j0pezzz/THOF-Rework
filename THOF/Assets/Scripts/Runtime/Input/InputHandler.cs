namespace Runtime.Input
{
    public static class InputHandler
    {
        public static bool WasInteractPressed()
        {
            return GameData.Instance.inputActions.FindActionMap("UI").FindAction("Interact").WasPressedThisFrame();
        }

        public static bool WasInventoryPressed()
        {
            return GameData.Instance.inputActions.FindActionMap("UI").FindAction("Inventory").WasPressedThisFrame();
        }

        public static bool WasPausePressed()
        {
            return GameData.Instance.inputActions.FindActionMap("UI").FindAction("Pause").WasPressedThisFrame();
        }
    }
}