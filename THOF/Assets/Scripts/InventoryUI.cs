using System.Collections;
using System.Collections.Generic;
using Internal.Structures.UI;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Window> windows;
    [SerializeField] private List<Window> inventoryWindows;
    [SerializeField] private GameObject ownedItemTemplate;
    [SerializeField] private RectTransform ownedItemsTransform;
    [SerializeField] private GameObject equippedItemTemplate;
    [SerializeField] private RectTransform equippedItemTransform;

    public GameObject ui_Anchor;

    public GameObject weaponInfo;
    public Text weaponName;
    public Text weaponStrength;
    public Text weaponSpeed;
    public Text weaponHealing;

    public bool isOpen;

    Window _currentWindow;
    Window _currentInventoryWindow;

    private Dictionary<string, GameObject> _cacheUI = new();

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab)) return;
        
        CheckItems();
        ToggleUI();
    }

    public void ToggleUI()
    {
        isOpen = !isOpen;

        if (!isOpen)
        {
            ui_Anchor.SetActive(false);
            PlayerController.Instance.inAction = false;
            return;
        }

        if (!isOpen) return;

        if (Shop.Instance.isOpen)
        {
            Shop.Instance.ToggleUI();
        }

        if (ChestUI.Instance.isOpen)
        {
            ChestUI.Instance.ToggleUI();
        }

        ui_Anchor.SetActive(true);
        PlayerController.Instance.inAction = true;
    }

    public void OpenWindow(string windowName)
    {
        CloseCurrentWindow(); // Try to close current window always

        Window window = windows.Find(x => x.WindowName == windowName);

        if (window == null)
        {
            Debug.LogWarning($"No window found with name {windowName}");
            return;
        }

        _currentWindow = window;
        window.WindowRoot.SetActive(true);
    }

    void CloseCurrentWindow()
    {
        if (_currentWindow == null) return;

        _currentWindow.WindowRoot.SetActive(false);
        _currentWindow = null;
    }

    public void OpenInventoryWindow(string windowName)
    {
        CloseCurrentInventoryWindow(); // Try to close current window always

        Window window = inventoryWindows.Find(x => x.WindowName == windowName);

        if (window == null)
        {
            Debug.LogWarning($"No inventory window found with name {windowName}");
            return;
        }

        _currentInventoryWindow = window;
        window.WindowRoot.SetActive(true);
    }
    
    void CloseCurrentInventoryWindow()
    {
        if (_currentInventoryWindow == null) return;

        _currentInventoryWindow.WindowRoot.SetActive(false);
        _currentInventoryWindow = null;
    }

    void CleanUI()
    {
        
    }

    public void CheckItems()
    {
        foreach (ShopItem ownedItem in Stats.Instance.items)
        {
            if (_cacheUI.ContainsKey(ownedItem.itemName)) continue;
            
            GameObject item = Instantiate(ownedItemTemplate, ownedItemsTransform);

            if (!item.TryGetComponent(out OwnedItemUI itemUI))
            {
                Debug.LogError("ownedItemTemplate does not have <b>OwnedItemUI<b>");
                Destroy(item);
                continue;
            }
            
            itemUI.SetItemData(ownedItem);
            _cacheUI.Add(ownedItem.itemName, item);
        }

        foreach (ShopItem currentAttack in Stats.Instance.equippedItems)
        {
            if (_cacheUI.ContainsKey(currentAttack.itemName)) continue;
            
            GameObject item = Instantiate(equippedItemTemplate, equippedItemTransform);
            
            if (!item.TryGetComponent(out EquippedAttackUI equippedItemUI))
            {
                Debug.LogError("ownedItemTemplate does not have <b>EquippedAttackUI<b>");
                Destroy(item);
                continue;
            }
            
            equippedItemUI.SetItemData(currentAttack);
            _cacheUI.Add(currentAttack.itemName, item);
        }
    }

    public void ShowWeaponInfo(Button btn)
    {
        if (btn.tag == "Attack1")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "Attack2")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "Attack3")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "Attack4")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "Attack5")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "Attack6")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "Attack7")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "Attack8")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponNameE.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenghtE.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeedE.ToString();
            //weaponHealing.text = "Healing: " + Stats.Instance.realHealingE.ToString();
        }

        if (btn.tag == "nAttack1")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponName1.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenght.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeed.ToString();
            weaponHealing.text = "";
        }

        if (btn.tag == "nAttack2")
        {
            weaponInfo.SetActive(true);
            //weaponName.text = Stats.Instance.weaponName2.ToString();
            //weaponStrength.text = "Strength: " + Stats.Instance.realStrenght2.ToString();
            //weaponSpeed.text = "Speed: " + Stats.Instance.realSpeed2.ToString();
            weaponHealing.text = "";
        }
    }

    public void CloseInfo()
    {
        weaponInfo.SetActive(false);
    }

    static InventoryUI _instance;
    public static InventoryUI Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<InventoryUI>();
            return _instance;
        }
    }
}