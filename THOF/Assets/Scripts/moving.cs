using UnityEngine;
using UnityEngine.UI;
using Internal.Structures.Save_System;

public class moving : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    Vector2 _movement;

    public bool inAction;
    public bool in1;
    public bool canGoIn;
    public bool canGoOut;
    public bool nearEnemy;

    public Transform outside;
    public Transform inside;
    public GameObject player;
    public GameObject vittu;

    Rigidbody2D _rb;
    Animator _animator;

    [HideInInspector]
    public Text chestText;
    [HideInInspector]
    public bool inShop;
    public bool inChest;

    public Camera Cam;

    void Start()
    {
        TryGetComponent(out _rb);
        TryGetComponent(out _animator);

        LoadPlayer();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        CamFollow();
        Door();
        Person();
    }

    public void SavePlayer()
    {
        if (Stats.Instance == null)
        {
            Debug.LogWarning("Stats not found, not trying to save.");
            return;
        }
        
        SaveSystem.SavePlayer(Stats.Instance);
    }

    void LoadPlayer()
    {
        if (!SaveSystem.LoadPlayer()) return;
        
        SaveData saveData = SaveSystem.SaveData;
        Stats.Instance.level = saveData.Level;
        Stats.Instance.coins = saveData.Coins;
        Stats.Instance.health = saveData.Health;
        player.transform.position = saveData.Position;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);

        if (!inAction)
        {
            moveSpeed = 2.5f;
        }

        if (inAction)
        {
            moveSpeed = 0f;
        }
    }

    void Door()
    {
        if (canGoIn && Input.GetKeyDown(KeyCode.E))
        {
            if (in1 == false)
            {
                in1 = true;
                player.transform.position = inside.transform.position;
                vittu.SetActive(false);
                canGoIn = false;
            }  
        }

        if (!canGoOut || !Input.GetKeyDown(KeyCode.E)) return;

        if (!in1) return;
        
        in1 = false;
        player.transform.position = outside.transform.position;
        vittu.SetActive(false);
        canGoOut = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door1"))
        {
            if (!in1)
            {
                canGoIn = true;
                vittu.SetActive(true);
            }
            
            if (in1)
            {
                canGoOut = true;
                vittu.SetActive(true);
            }
        }

        #region Enemies
        switch (collision.tag)
        {
            case "GrassEnemy1":
                Battle.Instance.isEnemy1 = true;
                Battle.Instance.eIconK1.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isGr1 = true;
                break;
            case "GrassEnemy2":
                Battle.Instance.isEnemy2 = true;
                Battle.Instance.eIconK1.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isGr2 = true;
                break;
            case "GrassEnemy3":
                Battle.Instance.isEnemy3 = true;
                Battle.Instance.eIconK1.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isGr3 = true;
                break;
            case "GrassEnemy4":
                Battle.Instance.isEnemy4 = true;
                Battle.Instance.eIconK1.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isGr4 = true;
                break;
            case "IceEnemy1":
                Battle.Instance.isEnemy5 = true;
                Battle.Instance.eIconK4.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isIc1 = true;
                break;
            case "IceEnemy2":
                Battle.Instance.isEnemy6 = true;
                Battle.Instance.eIconK4.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isIc2 = true;
                break;
            case "IceEnemy3":
                Battle.Instance.isEnemy7 = true;
                Battle.Instance.eIconK4.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isIc3 = true;
                break;
            case "IceEnemy4":
                Battle.Instance.isEnemy8 = true;
                Battle.Instance.eIconK4.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isIc4 = true;
                break;
            case "DesertEnemy1":
                Battle.Instance.isEnemy9 = true;
                Battle.Instance.eIconK3.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isDe1 = true;
                break;
            case "DesertEnemy2":
                Battle.Instance.isEnemy10 = true;
                Battle.Instance.eIconK3.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isDe2 = true;
                break;
            case "DesertEnemy3":
                Battle.Instance.isEnemy11 = true;
                Battle.Instance.eIconK3.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isDe3 = true;
                break;
            case "DesertEnemy4":
                Battle.Instance.isEnemy12 = true;
                Battle.Instance.eIconK3.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isDe4 = true;
                break;
            case "MountainEnemy1":
                Battle.Instance.isEnemy13 = true;
                Battle.Instance.eIconK2.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isMo1 = true;
                break;
            case "MountainEnemy2":
                Battle.Instance.isEnemy14 = true;
                Battle.Instance.eIconK2.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isMo2 = true;
                break;
            case "MountainEnemy3":
                Battle.Instance.isEnemy15 = true;
                Battle.Instance.eIconK2.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isMo3 = true;
                break;
            case "MountainEnemy4":
                Battle.Instance.isEnemy16 = true;
                Battle.Instance.eIconK2.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isMo4 = true;
                break;
            case "SIH1":
                Battle.Instance.isSIH1 = true;
                Battle.Instance.eIconSIH1.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isSIH1 = true;
                break;
            case "SIH2":
                Battle.Instance.isSIH2 = true;
                Battle.Instance.eIconSIH2.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isSIH2 = true;
                break;
            case "SIH3":
                Battle.Instance.isSIH3 = true;
                Battle.Instance.eIconSIH3.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isSIH3 = true;
                break;
            case "SIH4":
                Battle.Instance.isSIH4 = true;
                Battle.Instance.eIconSIH4.SetActive(true);
                nearEnemy = true;
                Dialog.Instance.isSIH4 = true;
                break;
            case "Shop":
                UIReferences.Instance.ActivateOpenShop(true);
                inShop = true;
                Shop.Instance.inShop1 = true;
                break;
            case "Shop2":
                UIReferences.Instance.ActivateOpenShop(true);
                inShop = true;
                Shop.Instance.inShop2 = true;
                break;
            case "Shop3":
                UIReferences.Instance.ActivateOpenShop(true);
                inShop = true;
                Shop.Instance.inShop3 = true;
                break;
            case "chest":
                chestText.enabled = true;
                inChest = true;
                break;
        }

        #endregion
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canGoIn = false;
        canGoOut = false;
        vittu.SetActive(false);

        switch (other.tag)
        {
            case "Shop":
                UIReferences.Instance.ActivateOpenShop(false);
                Shop.Instance.OpenShop(false);
                inShop = false;
                Shop.Instance.inShop1 = false;
                break;
            case "Shop2":
                UIReferences.Instance.ActivateOpenShop(false);
                Shop.Instance.OpenShop(false);
                inShop = false;
                Shop.Instance.inShop2 = false;
                break;
            case "Shop3":
                UIReferences.Instance.ActivateOpenShop(false);
                Shop.Instance.OpenShop(false);
                inShop = false;
                Shop.Instance.inShop3 = false;
                break;
            case "chest":
                chestText.enabled = false;
                ChestUI.Instance.CloseChestUI();
                chestText.text = "Press E to Open Chest";
                inChest = false;
                break;
            case "GrassEnemy1":
                nearEnemy = false;
                Dialog.Instance.isGr1 = false;
                break;
            case "GrassEnemy2":
                nearEnemy = false;
                Dialog.Instance.isGr2 = false;
                break;
            case "GrassEnemy3":
                nearEnemy = false;
                Dialog.Instance.isGr3 = false;
                break;
            case "GrassEnemy4":
                nearEnemy = false;
                Dialog.Instance.isGr4 = false;
                break;
            case "IceEnemy1":
                nearEnemy = false;
                Dialog.Instance.isIc1 = false;
                break;
            case "IceEnemy2":
                nearEnemy = false;
                Dialog.Instance.isIc2 = false;
                break;
            case "IceEnemy3":
                nearEnemy = false;
                Dialog.Instance.isIc3 = false;
                break;
            case "IceEnemy4":
                nearEnemy = false;
                Dialog.Instance.isIc4 = false;
                break;
            case "DesertEnemy1":
                nearEnemy = false;
                Dialog.Instance.isDe1 = false;
                break;
            case "DesertEnemy2":
                nearEnemy = false;
                Dialog.Instance.isDe2 = false;
                break;
            case "DesertEnemy3":
                nearEnemy = false;
                Dialog.Instance.isDe3 = false;
                break;
            case "DesertEnemy4":
                nearEnemy = false;
                Dialog.Instance.isDe4 = false;
                break;
            case "MountainEnemy1":
                nearEnemy = false;
                Dialog.Instance.isMo1 = false;
                break;
            case "MountainEnemy2":
                nearEnemy = false;
                Dialog.Instance.isMo2 = false;
                break;
            case "MountainEnemy3":
                nearEnemy = false;
                Dialog.Instance.isMo3 = false;
                break;
            case "MountainEnemy4":
                nearEnemy = false;
                Dialog.Instance.isMo4 = false;
                break;
            case "SIH1":
                nearEnemy = false;
                Dialog.Instance.isSIH1 = false;
                break;
            case "SIH2":
                nearEnemy = false;
                Dialog.Instance.isSIH2 = false;
                break;
            case "SIH3":
                nearEnemy = false;
                Dialog.Instance.isSIH3 = false;
                break;
            case "SIH4":
                nearEnemy = false;
                Dialog.Instance.isSIH4 = false;
                break;
        }
    }

    void Person()
    {
        if (nearEnemy && inAction == false)
        {
            vittu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                inAction = true;
                vittu.SetActive(false);
                Dialog.Instance.BoxOn();
                Dialog.Instance.WhoIsIt();
            }
        }

        if (!nearEnemy && !canGoIn && canGoOut)
        {
            vittu.SetActive(false);
        }
    }

    void CamFollow()
    {
        Vector3 followPosition = new Vector3(transform.position.x, transform.position.y, Cam.transform.position.z);
        Cam.transform.position = followPosition;
    }
}
