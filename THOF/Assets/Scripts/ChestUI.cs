using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : MonoBehaviour
{
    [SerializeField] private GameObject contentRoot;
    public bool isOpen;

    public ChestItems coins;

    public Image item1;
    public Text item1_text;

    public Button btn_1;

    public Text takeText;

    void Start()
    {
        takeText.text = "";
        item1_text.text = "";
    }

    void Update()
    {
        if (!PlayerController.Instance.inChest) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            if (InventoryUI.Instance.isOpen)
            {
                InventoryUI.Instance.OpenUI();
            }
            
            transform.GetChild(0).gameObject.SetActive(true);
            PlayerController.Instance.chestText.text = "Press E To Close Chest";
            CheckItems();
        }

        if (isOpen) return;
        
        transform.GetChild(0).gameObject.SetActive(false);
        PlayerController.Instance.chestText.text = "Press E To Open Chest";
    }

    public void CloseChestUI()
    {
        contentRoot.SetActive(false);
        isOpen = false;
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
        Stats.Instance.coins += coins.amount;
        takeText.text = $"You got {coins.amount} {coins.type}";
        StartCoroutine(TakeWait());
    }

    IEnumerator TakeWait()
    {
        yield return new WaitForSeconds(2);
        takeText.text = "";
    }

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
