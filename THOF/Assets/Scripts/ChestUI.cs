using System.Collections.Generic;
using Runtime.UI.Chest;
using UnityEngine;
using EventHandler = Internal.EventHandler;

public class ChestUI : MonoBehaviour
{
    [SerializeField] private GameObject contentRoot;
    [SerializeField] private RectTransform itemTransform;
    [SerializeField] private GameObject chestItemTemplate;
    
    bool _isOpen;
    private bool _canOpen;
    private readonly Dictionary<string, GameObject> _cacheUI = new();

    void Start()
    {
        EventHandler.Player.OnPlayerEnterChest += OnPlayerEnterChest;
    }

    void OnDisable()
    {
        EventHandler.Player.OnPlayerEnterChest -= OnPlayerEnterChest;
    }

    public void InitializeChestItems(List<ChestItem> chestItems)
    {
        CleanUI();
        foreach (ChestItem chestItem in chestItems)
        {
            GameObject chestItemObj = Instantiate(chestItemTemplate, itemTransform);

            if (!chestItemObj.TryGetComponent(out ChestItemUI itemUI))
            {
                Debug.LogError("chestItemTemplate does not have <b>ChestItemUI<b> attached!");
                Destroy(chestItemObj);
                continue;
            }
            
            itemUI.InitializeItem(chestItem);
            _cacheUI.Add(chestItem.identifier, chestItemObj);
        }
    }

    public void RemoveChestItem(string itemName)
    {
        GameObject chestItem = _cacheUI[itemName];

        if (!chestItem)
        {
            Debug.LogError($"No item found with name {itemName}!");
            return;
        }
        
        Destroy(chestItem);
        _cacheUI.Remove(itemName);
    }

    void CleanUI()
    {
        foreach (var item in _cacheUI)
        {
            Destroy(item.Value);
        }
        
        _cacheUI.Clear();
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
        }

        if (_isOpen) return;
        
        contentRoot.gameObject.SetActive(false);
    }

    public void CloseChestUI()
    {
        contentRoot.SetActive(false);
        _isOpen = false;
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
