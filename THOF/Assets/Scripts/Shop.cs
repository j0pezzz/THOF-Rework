using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Internal.Enums;
using Runtime.UI.Shop;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = Internal.EventHandler;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopWindowContent;
    [SerializeField] private RectTransform itemContent;
    [SerializeField] private GameObject itemTemplate;
    
    PlayerController player;

    [HideInInspector]
    public bool isOpen;
    public bool inShop1;
    public bool inShop2;
    public bool inShop3;
    
    public Image item1;
    public Image item2;
    public Image item3;
    public Image item5;
    public Image item6;
    public Image item7;
    public Image item8;

    public Text item1_text;
    public Text item2_text;
    public Text item3_text;

    public ShopItem snow;
    public ShopItem blade;
    public ShopItem charge;
    public ShopItem castle;
    public ShopItem water;
    public ShopItem shock;
    public ShopItem arson;

    public GameObject hp;
    public GameObject shop1;
    public GameObject shop2;

    ShopItem _shopItem;
    private List<ShopItem> _items;
    private readonly Dictionary<string, GameObject> _cacheUI = new();

    private void Start()
    {
        _items = GameData.Instance.shopItems; // Cache all items for later use.
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        EventHandler.OnEnterShop += OnEnterShop;
        EventHandler.OnExitShop += OnExitShop;
    }

    private void OnDisable()
    {
        EventHandler.OnEnterShop -= OnEnterShop;
        EventHandler.OnExitShop -= OnExitShop;
    }

    void OnEnterShop()
    {
        UIReferences.Instance.ActivateOpenShop();
    }
    
    void OnExitShop()
    {
        UIReferences.Instance.ActivateCloseShop(true);
    }

    void Update()
    {
        if (!player.inShop) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }
    }

    public void OpenShop()
    {
        isOpen = !isOpen;

        // If shop is open, initialize items.
        if (isOpen)
        {
            if (InventoryUI.Instance.isOpen)
            {
                InventoryUI.Instance.OpenUI();
            }
            
            UIReferences.Instance.ActivateCloseShop();
            InitializeItems();
        }
        else
        {
            UIReferences.Instance.ActivateOpenShop();
        }
        
        shopWindowContent.SetActive(isOpen);

        /*if (isOpen && InventoryUI.Instance.isOpen)
        {
            ChangeItems();
            shopWindowContent.SetActive(true);
            InventoryUI.Instance.ui_Anchor.SetActive(false);
            InventoryUI.Instance.isOpen = false;
            player.inAction = false;
        }
        else
        {
            ChangeItems();
            shopWindowContent.SetActive(true);
        }

        if (isOpen) return;
        
        shopWindowContent.SetActive(false);
        */
    }

    void InitializeItems()
    {
        CleanShopUI();
        
        if (inShop1)
        {
            List<ShopItem> shop1Items = _items.FindAll(x => x.shopType == ShopType.Shop1);

            foreach (ShopItem item in shop1Items)
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

            Debug.Log("Changed items for Shop 1!");
        }

        if (inShop2)
        {
            item1.sprite = snow.image;
            item1_text.text = snow.itemName + " for " + snow.howMuch + " Coins";
            item1.tag = "Attack8";

            item2.sprite = water.image;
            item2_text.text = water.itemName + " for " + water.howMuch + " Coins";
            item2.tag = "Attack3";

            item1.enabled = true;
            item1_text.enabled = true;
            item2.enabled = true;
            item2_text.enabled = true;
            item3.enabled = false;
            item3_text.enabled = false;

            Debug.Log("changed items for shop2");
        }

        if (inShop3)
        {
            item1.sprite = arson.image;
            item1_text.text = arson.itemName + " for " + arson.howMuch + " Coins";
            item1.tag = "Attack7";

            item2.sprite = shock.image;
            item2_text.text = shock.itemName + " for " + shock.howMuch + " Coins";
            item2.tag = "Attack6";

            item3.sprite = blade.image;
            item3_text.text = blade.itemName + " for " + blade.howMuch + " Coins";
            item3.tag = "Attack5";


            item1.enabled = true;
            item1_text.enabled = true;
            item2.enabled = true;
            item2_text.enabled = true;
            item3.enabled = true;
            item3_text.enabled = true;

            Debug.Log("changed items for shop3");
        }
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
        isOpen = active;
    }

    private static Shop _instance;

    public static Shop Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<Shop>();
            return _instance;
        }
    }
}
