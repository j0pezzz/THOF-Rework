using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Internal.Enums;
using Runtime.UI.Shop;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopWindowContent;
    [SerializeField] private RectTransform itemContent;
    [SerializeField] private GameObject itemTemplate;
    
    moving player;

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
    private Dictionary<string, GameObject> _cacheUI;

    private void Start()
    {
        _items = GameData.Instance.shopItems; // Cache all items for later use.
        player = GameObject.Find("Player").GetComponent<moving>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.inShop) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }
    }

    void OpenShop()
    {
        isOpen = !isOpen;

        if (isOpen && InventoryUI.Instance.isOpen)
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

    }

    void ChangeItems()
    {
        // Dirty way to clean the UI.
        foreach (var item in _cacheUI)
        {
            Destroy(item.Value);
            _cacheUI.Remove(item.Key);
        }
        
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
                _cacheUI.TryAdd(item.itemName, itemUI);
            }
            
            /*item1.sprite = charge.image;
            item1_text.text = charge.itemName + " for " + charge.howMuch + " Coins";
            item1.tag = "Attack1";

            item2.sprite = castle.image;
            item2_text.text = castle.itemName + " for " + castle.howMuch + " Coins";
            item2.tag = "Attack2";

            item1.enabled = true;
            item1_text.enabled = true;
            
            item2.enabled = true;
            item2_text.enabled = true;
            
            item3.enabled = false;
            item3_text.enabled = false;*/

            Debug.Log("changed items for shop1");
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
