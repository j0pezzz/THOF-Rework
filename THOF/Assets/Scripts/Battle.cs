using System.Collections;
using System.Collections.Generic;
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

    //int ogPH;
    public int ogEH;
    int enemyHP = 5;
    int enemyAD;
    int enemyAS;

    PlayerController Mo;
    Stats St;
    Enemy Gr;
    GrassEnemy2 Gr2;
    GrassEnemy3 Gr3;
    GrassEnemy4 Gr4;
    SIH1 S1;
    IceEnemy Ic;
    IceEnemy2 Ic2;
    IceEnemy3 Ic3;
    IceEnemy4 Ic4;
    SIH2 S2;
    DesertEnemy De;
    DesertEnemy2 De2;
    DesertEnemy3 De3;
    DesertEnemy4 De4;
    SIH3 S3;
    MountainEnemy Mo1;
    MountainEnemy2 Mo2;
    MountainEnemy3 Mo3;
    MountainEnemy4 Mo4;
    SIH4 S4;


    void Start()
    {
        Mo = GameObject.Find("Player").GetComponent<PlayerController>();
        St = GameObject.Find("Player").GetComponent<Stats>();
        Gr = GameObject.Find("enemy").GetComponent<Enemy>();
        Gr2 = GameObject.Find("enemy2").GetComponent<GrassEnemy2>();
        Gr3 = GameObject.Find("enemy3").GetComponent<GrassEnemy3>();
        Gr4 = GameObject.Find("enemy4").GetComponent<GrassEnemy4>();
        S1 = GameObject.Find("Semi Iso Herra1").GetComponent<SIH1>();
        Ic = GameObject.Find("enemy5").GetComponent<IceEnemy>();
        Ic2 = GameObject.Find("enemy6").GetComponent<IceEnemy2>();
        Ic3 = GameObject.Find("enemy7").GetComponent<IceEnemy3>();
        Ic4 = GameObject.Find("enemy8").GetComponent<IceEnemy4>();
        S2 = GameObject.Find("Semi Iso Herra2").GetComponent<SIH2>();
        De = GameObject.Find("enemy9").GetComponent<DesertEnemy>();
        De2 = GameObject.Find("enemy10").GetComponent<DesertEnemy2>();
        De3 = GameObject.Find("enemy11").GetComponent<DesertEnemy3>();
        De4 = GameObject.Find("enemy12").GetComponent<DesertEnemy4>();
        S3 = GameObject.Find("Semi Iso Herra3").GetComponent<SIH3>();
        Mo1 = GameObject.Find("enemy13").GetComponent<MountainEnemy>();
        Mo2 = GameObject.Find("enemy14").GetComponent<MountainEnemy2>();
        Mo3 = GameObject.Find("enemy15").GetComponent<MountainEnemy3>();
        Mo4 = GameObject.Find("enemy16").GetComponent<MountainEnemy4>();
        S4 = GameObject.Find("Semi Iso Herra4").GetComponent<SIH4>();

        //attack1.text = St.weaponName1;
        //attack2.text = St.weaponName2;
        //attackE.text = St.weaponNameE;
    }

    void Update()
    {
        //attack1.text = St.weaponName1;
        //attack2.text = St.weaponName2;
        //attackE.text = St.weaponNameE;

        CheckHealth();
    }

    private EnemyBase _currentEnemy;

    public void SetEnemy(EnemyBase enemy)
    {
        _currentEnemy = enemy;
        enemyIcon.sprite = enemy.EnemySprite;
    }

    public void Begin()
    {
        battlePanel.SetActive(true);
        xpGivenText.SetActive(false);


        if (_currentEnemy == null)
        {
            Debug.LogError("No enemy!");
            return;
        }

        enemyHP = _currentEnemy.Health;
        enemyAS = _currentEnemy.Speed;
        enemyAD = _currentEnemy.Strength;
        ogEH = _currentEnemy.Health;
    }

    public void Stop()
    {
        battlePanel.SetActive(false);
        Mo.inAction = false;
        isAttacking = false;
        St.health = St.fullHealth;
    }

    IEnumerator BattleOver()
    {
        yield return new WaitForSeconds(1);
        losePanel.SetActive(false);
        battlePanel.SetActive(false);
        isAttacking = false;
        Mo.inAction = false;
        St.health = St.fullHealth;
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
        coinsGiven.text = St.coinsAfter.ToString() + " coins";
        St.coins += St.coinsAfter;
        yield return new WaitForSeconds(1);
        xpGivenText.SetActive(false);
        coinsGiven.enabled = false;
        StartCoroutine(BattleOver());
        GiveXp();
    }

    void GiveXp()
    {
        St.xp += ogEH;
    }

    void CheckHealth()
    {
        if (enemyHP < 0)
        {
            enemyHP = 0;
        }
        
        enemyHPText.text = enemyHP.ToString();

        if (St.health <= 0)
        {
            StartCoroutine(PlayerDead());
        }

        if (enemyHP <= 0)
        {
            StartCoroutine(EnemyDead());
        }
    }

    public void Attack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(Attack1());
        }
    }

    public void SecondAttack()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(Attack2());
        }
    }

    public void Attack3()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(AttackE());
        }
    }

    IEnumerator Attack1()
    {
        yield return null;
        /*if (St.realSpeed >= enemyAS)
        {
            enemyHP -= St.realStrenght;
            yield return new WaitForSeconds(1);

            if (enemyHP > 0)
            {
                St.health -= enemyAD;
            }

            isAttacking = false;
        }

        else if (St.realSpeed < enemyAS)
        {
            St.health -= enemyAD;
            yield return new WaitForSeconds(1);

            if (St.health > 0)
            {
                enemyHP -= St.realStrenght;
            }

            isAttacking = false;
        }*/
    }

    IEnumerator Attack2()
    {
        yield return null;
        /*if (St.realSpeed2 >= enemyAS)
        {
            enemyHP -= St.realStrenght2;
            yield return new WaitForSeconds(1);

            if (enemyHP > 0)
            {
                St.health -= enemyAD;
            }

            isAttacking = false;
        }

        else if (St.realSpeed2 < enemyAS)
        {
            St.health -= enemyAD;
            yield return new WaitForSeconds(1);

            if (St.health > 0)
            {
                enemyHP -= St.realStrenght2;
            }

            isAttacking = false;
        }*/
    }

    IEnumerator AttackE()
    {
        yield return null;
        /*if (St.realSpeedE >= enemyAS)
        {
            enemyHP -= St.realStrenghtE;

            if (St.realHealingE > 0)
            {
                St.health += St.realHealingE;
                
                if (St.health > St.fullHealth)
                {
                    St.health = St.fullHealth;
                }
            }
            
            yield return new WaitForSeconds(1);

            if (enemyHP > 0)
            {
                St.health -= enemyAD;
            }

            isAttacking = false;
        }

        else if (St.realSpeedE < enemyAS)
        {
            St.health -= enemyAD;
            yield return new WaitForSeconds(1);

            if (St.health > 0)
            {
                enemyHP -= St.realStrenghtE;
                if (St.realHealingE > 0)
                {
                    St.health += St.realHealingE;

                    if (St.health > St.fullHealth)
                    {
                        St.health = St.fullHealth;
                    }
                }
            }

            isAttacking = false;
        }*/
    }

    private static Battle _instance;

    public static Battle Instance
    {
        get
        {
            if  (_instance == null) _instance = FindAnyObjectByType<Battle>();
            return _instance;
        }
    }
}
