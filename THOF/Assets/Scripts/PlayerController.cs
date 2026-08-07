using System;
using Internal.Enums;
using Internal.Structures;
using Runtime.Input;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = Internal.EventHandler;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    Vector2 _movement;

    public bool inAction;
    public bool in1;
    public bool canGoIn;
    public bool canGoOut;
    public bool nearEnemy;

    public Transform outside;
    public Transform inside;

    [HideInInspector] public bool inShop;

    public Camera cam;

    void Start()
    {
        EventHandler.OnEnterShop += OnEnterShop;
        EventHandler.OnExitShop += OnExitShop;
    }

    void OnDisable()
    {
        EventHandler.OnEnterShop -= OnEnterShop;
        EventHandler.OnExitShop -= OnExitShop;
    }

    void OnEnterShop(ShopType shopType) => inShop = true;

    void OnExitShop()
    {
        inShop = false;
        ShopUI.Instance.OpenShop(false);
    }

    void Update()
    {
        _movement.x = GameData.Instance.inputActions.FindActionMap("Player Movement").FindAction("Move").ReadValue<Vector2>().x;
        _movement.y = GameData.Instance.inputActions.FindActionMap("Player Movement").FindAction("Move").ReadValue<Vector2>().y;
        
        //TODO: create separate animation script where we handle this.
        animator.SetFloat("Horizontal", _movement.x);
        animator.SetFloat("Vertical", _movement.y);
        animator.SetFloat("Speed", _movement.sqrMagnitude);

        CamFollow();
        Door();
        Person();
        InteractWithEnemy();
    }

    void InteractWithEnemy()
    {
        // If we are near an enemy and not yet in action.
        if (!nearEnemy || inAction) return;

        if (!InputHandler.WasInteractPressed()) return;
        
        inAction = true;
        UIReferences.Instance.ShowInteract(false);
        Dialog.Instance.StartDialog();
    }
    
    void Person()
    {
        if (!nearEnemy && !canGoIn && canGoOut)
        {
            UIReferences.Instance.ShowInteract(false);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));

        moveSpeed = !inAction ? 2.5f : 0;
    }

    //TODO: create proper door system instead of using THIS.
    // we could have a door script which has all the positions and we just get the positions from there or something.
    void Door()
    {
        if (canGoIn && InputHandler.WasInteractPressed())
        {
            if (!in1)
            {
                in1 = true;
                SetPosition(inside.transform.position);
                UIReferences.Instance.ShowInteract(false);
                canGoIn = false;
            }  
        }

        if (!canGoOut || !InputHandler.WasInteractPressed()) return;

        if (!in1) return;
        
        in1 = false;
        SetPosition(outside.transform.position);
        UIReferences.Instance.ShowInteract(false);
        canGoOut = false;
    }

    /// <summary>
    /// This is mainly used to force set saved game position.
    /// </summary>
    /// <param name="position"></param>
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    //TODO: we should be having all these interactions on their own classes instead of checking for every single thing in here.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Door1")) return;
        
        if (!in1)
        {
            canGoIn = true;
            UIReferences.Instance.ShowInteract(true);
        }

        if (!in1) return;
            
        canGoOut = true;
        UIReferences.Instance.ShowInteract(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canGoIn = false;
        canGoOut = false;
    }

    void CamFollow()
    {
        Vector3 followPosition = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        cam.transform.position = followPosition;
    }
    
    public void EnemyRadius(bool closeToEnemy) => nearEnemy = closeToEnemy;

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
