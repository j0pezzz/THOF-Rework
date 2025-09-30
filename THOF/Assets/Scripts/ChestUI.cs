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

    Stats stats;
    moving player;


    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<Stats>();
        player = GameObject.Find("Player").GetComponent<moving>();

        takeText.text = "";
        item1_text.text = "";
    }

    void Update()
    {
        if (player.inChest && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        isOpen = !isOpen;

        if (isOpen && InventoryUI.Instance.isOpen)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            InventoryUI.Instance.ui_Anchor.SetActive(false);
            InventoryUI.Instance.isOpen = false;
            player.chestText.text = "Press E To Close Chest";
            player.inAction = false;
            CheckItems();
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            player.chestText.text = "Press E To Close Chest";
            CheckItems();
        }

        if (!isOpen)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            player.chestText.text = "Press E To Open Chest";
        }
    }

    public void CloseChestUI()
    {
        contentRoot.SetActive(false);
        isOpen = false;
    }

    void CheckItems()
    {
        if (coins.inChest)
        {
            item1.sprite = coins.image;
            item1_text.text = coins.amount.ToString() + coins.type.ToString();
        }
    }

    public void TakeStuff(Button btn)
    {
        if (btn.tag == "Coins")
        {
            item1.enabled = false;
            stats.coins += coins.amount;
            takeText.text = "You got " + coins.amount.ToString() + coins.type.ToString();
            StartCoroutine(TakeWait());
        }
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
