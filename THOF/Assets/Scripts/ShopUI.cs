using System.Collections.Generic;
using Internal.Enums;
using Runtime.UI.Shop;
using UnityEngine;
using EventHandler = Internal.EventHandler;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopWindowContent;
    [SerializeField] private RectTransform itemContent;
    [SerializeField] private GameObject itemTemplate;

    bool _isOpen;
    ShopItem _shopItem;
    private List<ShopItem> _items;
    private readonly Dictionary<string, GameObject> _cacheUI = new();

    private void Start()
    {
        _items = GameData.Instance.shopItems; // Cache all items for later use.

        EventHandler.OnEnterShop += OnEnterShop;
        EventHandler.OnExitShop += OnExitShop;
    }

    private void OnDisable()
    {
        EventHandler.OnEnterShop -= OnEnterShop;
        EventHandler.OnExitShop -= OnExitShop;
    }

    private ShopType _currentShop = ShopType.None;

    void OnEnterShop(ShopType shopType)
    {
        _currentShop = shopType;
        UIReferences.Instance.ActivateOpenShop();
    }
    
    void OnExitShop()
    {
        _currentShop = ShopType.None;
        UIReferences.Instance.ActivateCloseShop(true);
    }

    void Update()
    {
        if (!PlayerController.Instance.inShop) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleUI();
        }
    }

    public void ToggleUI()
    {
        _isOpen = !_isOpen;

        // If shop is open, initialize items.
        if (_isOpen)
        {
            if (InventoryUI.Instance.isOpen)
            {
                InventoryUI.Instance.ToggleUI();
            }
            
            UIReferences.Instance.ActivateCloseShop();
            InitializeItems();
        }
        else
        {
            UIReferences.Instance.ActivateOpenShop();
        }
        
        shopWindowContent.SetActive(_isOpen);
    }

    void InitializeItems()
    {
        CleanShopUI();

        if (_currentShop == ShopType.None) return;
        
        HandleShopItems();
    }

    void HandleShopItems()
    {
        List<ShopItem> shopItems = _items.FindAll(x => x.shopType == _currentShop);

        foreach (ShopItem item in shopItems)
        {
            GameObject itemUI = Instantiate(itemTemplate, itemContent);

            if (!itemUI.TryGetComponent(out ShopItemUI shopItemUI))
            {
                Debug.LogError("Item Template did not have <b>ShopItemUI.cs<b> attached!");
                Destroy(itemUI);
                continue;
            }
                
            shopItemUI.SetItemData(item);
            itemUI.SetActive(true);
            _cacheUI.TryAdd(item.itemName, itemUI);
        }

        Debug.Log($"Changed items for {_currentShop}!");
    }

    /// <summary>
    /// Cleans the shop UI from all items.
    /// </summary>
    void CleanShopUI()
    {
        List<string> itemsToRemove = new();
        
        foreach (var item in _cacheUI)
        {
            itemsToRemove.Add(item.Key);
            Destroy(item.Value);
        }

        foreach (var itemToRemove in itemsToRemove)
        {
            _cacheUI.Remove(itemToRemove);
        }
    }

    public void OpenShop(bool active)
    {
        shopWindowContent.SetActive(active);
        _isOpen = active;
    }

    public bool IsOpen() => _isOpen;

    private static ShopUI _instance;

    public static ShopUI Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<ShopUI>();
            return _instance;
        }
    }
}
