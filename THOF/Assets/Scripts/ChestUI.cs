using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = Internal.EventHandler;

public class ChestUI : MonoBehaviour
{
    [SerializeField] private GameObject contentRoot;

    public ChestItems coins;

    public Image item1;
    public Text item1_text;

    public Button btn_1;

    public Text takeText;
    
    bool _isOpen;
    private bool _canOpen;

    void Start()
    {
        EventHandler.Player.OnPlayerEnterChest += OnPlayerEnterChest;
        takeText.text = "";
        item1_text.text = "";
    }

    void OnDisable()
    {
        EventHandler.Player.OnPlayerEnterChest -= OnPlayerEnterChest;
    }

    public void InitializeChestItems(List<ShopItem> chestItems)
    {
        //TODO: we need to instantiate all items which are in the chest we are about to open.
    }

    void OnPlayerEnterChest(bool enter)
    {
        _canOpen = enter;
    }

    void Update()
    {
        if (!_canOpen) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleUI();
        }
    }

    public void ToggleUI()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        {
            if (InventoryUI.Instance.isOpen)
            {
                InventoryUI.Instance.ToggleUI();
            }
            
            contentRoot.gameObject.SetActive(true);
            CheckItems();
        }

        if (_isOpen) return;
        
        contentRoot.gameObject.SetActive(false);
    }

    public void CloseChestUI()
    {
        contentRoot.SetActive(false);
        _isOpen = false;
    }

    void CheckItems()
    {
        if (!coins.inChest) return;
        
        item1.sprite = coins.image;
        item1_text.text = $"{coins.amount} {coins.type}";
    }

    public void TakeStuff(Button btn)
    {
        if (!btn.tag.Equals("Coins")) return;
        
        item1.enabled = false;
        Stats.Instance.AddCoins(coins.amount);
        takeText.text = $"You got {coins.amount} {coins.type}";
        StartCoroutine(TakeWait());
    }

    IEnumerator TakeWait()
    {
        yield return new WaitForSeconds(2);
        takeText.text = "";
    }

    public bool IsOpen() => _isOpen;

    private static ChestUI _instance;
    public static ChestUI Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<ChestUI>();
            return _instance;
        }
    }
}
