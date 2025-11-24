using System.Collections;
using Internal;
using Internal.Structures;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private Image enemyIcon;
    public GameObject battlePanel;
    public GameObject losePanel;
    public GameObject xpGivenText;


    public Text attack1;
    public Text attack2;
    public Text attackE;
    public Text enemyHPText;
    public Text xpGiven;
    public Text coinsGiven;

    public bool isAttacking;

    public int ogEH;
    int enemyHP = 5;
    int enemyAD;
    int enemyAS;
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
        
        EventHandler.Player.OnPlayerDead += OnPlayerDead;
        battlePanel.SetActive(true);
        xpGivenText.SetActive(false);

        enemyHP = _currentEnemy.Health;
        enemyAS = _currentEnemy.Speed;
        enemyAD = _currentEnemy.Strength;
        ogEH = _currentEnemy.Health;
        enemyHPText.text = enemyHP.ToString();
    }

    void OnPlayerDead() => StartCoroutine(PlayerDead());

    public void Stop()
    {
        EventHandler.Player.OnPlayerDead -= OnPlayerDead;
        battlePanel.SetActive(false);
        PlayerController.Instance.inAction = false;
        isAttacking = false;
        Stats.Instance.health = Stats.Instance.fullHealth;
    }

    IEnumerator BattleOver()
    {
        yield return new WaitForSeconds(1);
        losePanel.SetActive(false);
        battlePanel.SetActive(false);
        isAttacking = false;
        PlayerController.Instance.inAction = false;
        Stats.Instance.health = Stats.Instance.fullHealth;
        xpGivenText.SetActive(false);
    }

    IEnumerator PlayerDead()
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(2);
        StartCoroutine(BattleOver());
    }

    IEnumerator EnemyDead()
    {
        xpGiven.text = ogEH + "xp earned";
        _currentEnemy.IsFightable = false;
        
        xpGivenText.SetActive(true);
        coinsGiven.enabled = true;
        coinsGiven.text = $"{Stats.Instance.coinsAfter} coins";
        Stats.Instance.coins += Stats.Instance.coinsAfter;
        yield return new WaitForSeconds(1);
        xpGivenText.SetActive(false);
        coinsGiven.enabled = false;
        StartCoroutine(BattleOver());
        GiveXp();
    }

    void GiveXp()
    {
        Stats.Instance.xp += ogEH;
    }

    void ReduceEnemyHealth(int minusHealth)
    {
        enemyHP = Mathf.Clamp(enemyHP - minusHealth, 0, _currentEnemy.Health);
        
        enemyHPText.text = enemyHP.ToString();

        if (enemyHP <= 0)
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
        
        if (speed >= enemyAS)
        {
            ReduceEnemyHealth(strength);
            yield return new WaitForSeconds(1);

            if (enemyHP > 0)
            {
                Stats.Instance.ReduceHealth(enemyAD);
            }

            isAttacking = false;
        }

        else if (speed< enemyAS)
        {
            Stats.Instance.ReduceHealth(enemyAD);
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
        
        if (speed >= enemyAS)
        {
            ReduceEnemyHealth(strength);
            yield return new WaitForSeconds(1);

            if (enemyHP > 0)
            {
                Stats.Instance.ReduceHealth(enemyAD);
            }

            isAttacking = false;
        }
        else if (speed < enemyAS)
        {
            Stats.Instance.ReduceHealth(enemyAD);
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
        
        if (speed >= enemyAS)
        {
            ReduceEnemyHealth(strength);

            if (healing > 0)
            {
                Stats.Instance.AddHealth(healing);
            }
            
            yield return new WaitForSeconds(1);

            if (enemyHP > 0)
            {
                Stats.Instance.ReduceHealth(enemyAD);
            }

            isAttacking = false;
        }
        else if (speed < enemyAS)
        {
            Stats.Instance.ReduceHealth(enemyAD);
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
