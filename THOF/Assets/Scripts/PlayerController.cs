using Internal;
using Internal.Enums;
using Internal.Structures;
using UnityEngine;
using UnityEngine.UI;
using Internal.Structures.Save_System;

public class PlayerController : MonoBehaviour
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
        InteractWithEnemy();
    }

    void InteractWithEnemy()
    {
        // If we are near an enemy and not yet in action.
        if (!nearEnemy || inAction) return;

        if (!Input.GetKeyDown(KeyCode.E)) return;
        
        inAction = true;
        UIReferences.Instance.ShowInteract(false);
        Dialog.Instance.BoxOn();
    }
    
    void Person()
    {
        if (!nearEnemy && !canGoIn && canGoOut)
        {
            UIReferences.Instance.ShowInteract(false);
        }
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
        _rb.MovePosition(_rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));

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
            if (!in1)
            {
                in1 = true;
                player.transform.position = inside.transform.position;
                UIReferences.Instance.ShowInteract(false);
                canGoIn = false;
            }  
        }

        if (!canGoOut || !Input.GetKeyDown(KeyCode.E)) return;

        if (!in1) return;
        
        in1 = false;
        player.transform.position = outside.transform.position;
        UIReferences.Instance.ShowInteract(false);
        canGoOut = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door1"))
        {
            if (!in1)
            {
                canGoIn = true;
                UIReferences.Instance.ShowInteract(true);
            }
            
            if (in1)
            {
                canGoOut = true;
                UIReferences.Instance.ShowInteract(true);
            }
        }

        if (collision.transform.TryGetComponent(out EnemyBase enemyBase))
        {
            nearEnemy = true;
            Debug.Log("Enemy found");
            enemyBase.CheckEnemyFightStatus();
            Dialog.Instance.SetEnemyIcon(enemyBase.EnemySprite);
            Battle.Instance.SetEnemy(enemyBase);
            UIReferences.Instance.ShowInteract(true);
        }

        switch (collision.tag)
        {
            case "Shop":
                EventHandler.DispatchEnterShop();
                inShop = true;
                Shop.Instance.inShop1 = true;
                break;
            case "Shop2":
                EventHandler.DispatchEnterShop();
                inShop = true;
                Shop.Instance.inShop2 = true;
                break;
            case "Shop3":
                EventHandler.DispatchEnterShop();
                inShop = true;
                Shop.Instance.inShop3 = true;
                break;
            case "chest":
                chestText.enabled = true;
                inChest = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canGoIn = false;
        canGoOut = false;
        UIReferences.Instance.ShowInteract(false);

        if (other.transform.root.TryGetComponent(out EnemyBase enemyBase))
        {
            Debug.Log("No longer in enemy radius");
            nearEnemy = false;
        }

        switch (other.tag)
        {
            case "Shop":
                EventHandler.OnExitShop();
                Shop.Instance.OpenShop(false);
                inShop = false;
                Shop.Instance.inShop1 = false;
                break;
            case "Shop2":
                EventHandler.OnExitShop();
                Shop.Instance.OpenShop(false);
                inShop = false;
                Shop.Instance.inShop2 = false;
                break;
            case "Shop3":
                EventHandler.OnExitShop();
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
        }
    }

    void CamFollow()
    {
        Vector3 followPosition = new Vector3(transform.position.x, transform.position.y, Cam.transform.position.z);
        Cam.transform.position = followPosition;
    }

    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<PlayerController>();
            return _instance;
        }
    }
}
