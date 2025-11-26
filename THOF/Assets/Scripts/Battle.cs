using System.Collections;
using Internal;
using Internal.Structures;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private Image enemyIcon;
    [SerializeField] GameObject losePanel;
    [SerializeField] TextMeshProUGUI xpGivenText;
    [SerializeField] private TextMeshProUGUI enemyHpText;

    public Text attack1;
    public Text attack2;
    public Text attackE;
    public Text coinsGiven;

    public bool isAttacking;

    /// <summary>
    /// How much XP will the player get if they win?
    /// </summary>
    int _winXp;
    int _enemyHp = 5;
    int _enemyStrength;
    int _enemySpeed;
    private EnemyBase _currentEnemy;
    
    void Start()
    {
        attack1.text = Stats.Instance.equippedItems[0].itemName;
        attack2.text = Stats.Instance.equippedItems[1].itemName;
        attackE.text = Stats.Instance.equippedItems[2].itemName;
    }

    public void SetEnemy(EnemyBase enemy)
    {
        _currentEnemy = enemy;
        enemyIcon.sprite = enemy.EnemySprite;
    }

    public void Begin()
    {
        if (_currentEnemy == null)
        {
            Debug.LogError("No enemy!");
            return;
        }
        
        content.SetActive(true);
        
        EventHandler.Player.OnPlayerDead += OnPlayerDead;
        xpGivenText.gameObject.SetActive(false);

        _enemyHp = _currentEnemy.Health;
        _enemySpeed = _currentEnemy.Speed;
        _enemyStrength = _currentEnemy.Strength;
        _winXp = _currentEnemy.Health;
        enemyHpText.SetText(_enemyHp.ToString());
    }

    void OnPlayerDead() => StartCoroutine(PlayerDead());

    public void Stop()
    {
        EventHandler.Player.OnPlayerDead -= OnPlayerDead;
        content.SetActive(false);

        Stats.Instance.ResetHealth();
        PlayerController.Instance.inAction = false;
        isAttacking = false;
    }

    IEnumerator BattleOver()
    {
        yield return new WaitForSeconds(1);
        content.SetActive(false);
        losePanel.SetActive(false);
        isAttacking = false;
        PlayerController.Instance.inAction = false;
        Stats.Instance.ResetHealth();
        xpGivenText.gameObject.SetActive(false);
    }

    IEnumerator PlayerDead()
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(2);
        StartCoroutine(BattleOver());
    }

    IEnumerator EnemyDead()
    {
        xpGivenText.SetText($"{_winXp} XP FROM BATTLE");
        _currentEnemy.IsFightable = false;
        
        xpGivenText.gameObject.SetActive(true);
        coinsGiven.enabled = true;
        coinsGiven.text = $"{Stats.Instance.coinsAfter} coins";
        Stats.Instance.AddCoins();
        Stats.Instance.IncreaseXp(_winXp);

        yield return new WaitForSeconds(1);
        
        xpGivenText.gameObject.SetActive(false);
        coinsGiven.enabled = false;
        StartCoroutine(BattleOver());
    }

    void ReduceEnemyHealth(int minusHealth)
    {
        _enemyHp = Mathf.Clamp(_enemyHp - minusHealth, 0, _currentEnemy.Health);
        
        enemyHpText.SetText(_enemyHp.ToString());

        if (_enemyHp <= 0)
        {
            StartCoroutine(EnemyDead());
        }
    }

    public void Attack()
    {
        if (isAttacking) return;
        
        isAttacking = true;
        StartCoroutine(Attack1());
    }

    public void SecondAttack()
    {
        if (isAttacking) return;
        
        isAttacking = true;
        StartCoroutine(Attack2());
    }

    public void Attack3()
    {
        if (isAttacking) return;
        
        isAttacking = true;
        StartCoroutine(AttackE());
    }

    IEnumerator Attack1()
    {
        int speed = Stats.Instance.speed + Stats.Instance.equippedItems[0].speedIncrease;
        int strength = Stats.Instance.strenght + Stats.Instance.equippedItems[0].strengthIncrease;
        
        if (speed >= _enemySpeed)
        {
            ReduceEnemyHealth(strength);
            yield return new WaitForSeconds(1);

            if (_enemyHp > 0)
            {
                Stats.Instance.ReduceHealth(_enemyStrength);
            }

            isAttacking = false;
        }

        else if (speed< _enemySpeed)
        {
            Stats.Instance.ReduceHealth(_enemyStrength);
            yield return new WaitForSeconds(1);

            if (Stats.Instance.health > 0)
            {
                ReduceEnemyHealth(strength);
            }

            isAttacking = false;
        }
    }

    IEnumerator Attack2()
    {
        int speed = Stats.Instance.speed + Stats.Instance.equippedItems[1].speedIncrease;
        int strength = Stats.Instance.strenght + Stats.Instance.equippedItems[1].strengthIncrease;
        
        if (speed >= _enemySpeed)
        {
            ReduceEnemyHealth(strength);
            yield return new WaitForSeconds(1);

            if (_enemyHp > 0)
            {
                Stats.Instance.ReduceHealth(_enemyStrength);
            }

            isAttacking = false;
        }
        else if (speed < _enemySpeed)
        {
            Stats.Instance.ReduceHealth(_enemyStrength);
            yield return new WaitForSeconds(1);

            if (Stats.Instance.health > 0)
            {
                ReduceEnemyHealth(strength);
            }

            isAttacking = false;
        }
    }

    IEnumerator AttackE()
    {
        int speed = Stats.Instance.speed + Stats.Instance.equippedItems[2].speedIncrease;
        int strength = Stats.Instance.strenght + Stats.Instance.equippedItems[2].strengthIncrease;
        int healing = Stats.Instance.healing + Stats.Instance.equippedItems[2].healthIncrease;
        
        if (speed >= _enemySpeed)
        {
            ReduceEnemyHealth(strength);

            if (healing > 0)
            {
                Stats.Instance.AddHealth(healing);
            }
            
            yield return new WaitForSeconds(1);

            if (_enemyHp > 0)
            {
                Stats.Instance.ReduceHealth(_enemyStrength);
            }

            isAttacking = false;
        }
        else if (speed < _enemySpeed)
        {
            Stats.Instance.ReduceHealth(_enemyStrength);
            yield return new WaitForSeconds(1);

            if (Stats.Instance.health > 0)
            {
                ReduceEnemyHealth(strength);
                if (healing > 0)
                {
                    Stats.Instance.AddHealth(healing);
                }
            }

            isAttacking = false;
        }
    }

    private static Battle _instance;
    public static Battle Instance
    {
        get
        {
            if  (!_instance) _instance = FindAnyObjectByType<Battle>();
            return _instance;
        }
    }
}
