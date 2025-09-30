using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public GameObject battlePanel;
    public GameObject losePanel;
    public GameObject xpGivenText;
    public GameObject eIconK1;
    public GameObject eIconK2;
    public GameObject eIconK3;
    public GameObject eIconK4;
    public GameObject eIconSIH1;
    public GameObject eIconSIH2;
    public GameObject eIconSIH3;
    public GameObject eIconSIH4;


    public Text attack1;
    public Text attack2;
    public Text attackE;
    public Text enemyHPText;
    public Text xpGiven;
    public Text coinsGiven;

    public bool isAttacking;
    public bool isEnemy1;
    public bool isEnemy2;
    public bool isEnemy3;
    public bool isEnemy4;
    public bool isSIH1;
    public bool isEnemy5;
    public bool isEnemy6;
    public bool isEnemy7;
    public bool isEnemy8;
    public bool isSIH2;
    public bool isEnemy9;
    public bool isEnemy10;
    public bool isEnemy11;
    public bool isEnemy12;
    public bool isSIH3;
    public bool isEnemy13;
    public bool isEnemy14;
    public bool isEnemy15;
    public bool isEnemy16;
    public bool isSIH4;

    public bool pD = false;
    public bool e1D = false;
    public bool e2D = false;
    public bool e3D = false;
    public bool e4D = false;
    public bool SIH1D = false;
    public bool e5D = false;
    public bool e6D = false;
    public bool e7D = false;
    public bool e8D = false;
    public bool SIH2D = false;
    public bool e9D = false;
    public bool e10D = false;
    public bool e11D = false;
    public bool e12D = false;
    public bool SIH3D = false;
    public bool e13D = false;
    public bool e14D = false;
    public bool e15D = false;
    public bool e16D = false;
    public bool SIH4D = false;

    //int ogPH;
    public int ogEH;
    int enemyHP = 5;
    int enemyAD;
    int enemyAS;

    moving Mo;
    Stats St;
    GrassEnemy Gr;
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


    // Start is called before the first frame update
    void Start()
    {
        Mo = GameObject.Find("Player").GetComponent<moving>();
        St = GameObject.Find("Player").GetComponent<Stats>();
        Gr = GameObject.Find("enemy").GetComponent<GrassEnemy>();
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

        attack1.text = St.weaponName1;
        attack2.text = St.weaponName2;
        attackE.text = St.weaponNameE;
    }

    // Update is called once per frame
    void Update()
    {
        attack1.text = St.weaponName1;
        attack2.text = St.weaponName2;
        attackE.text = St.weaponNameE;

        CheckHealth();
    }

    public void Begin()
    {
        battlePanel.SetActive(true);
        xpGivenText.SetActive(false);


        if (isEnemy1 == true)
        {
            enemyHP = Gr.health;
            enemyAS = Gr.speed;
            enemyAD = Gr.strenght;
            ogEH = Gr.health;
        }

        if (isEnemy2 == true)
        {
            enemyHP = Gr2.health;
            enemyAS = Gr2.speed;
            enemyAD = Gr2.strenght;
            ogEH = Gr2.health;
        }

        if (isEnemy3 == true)
        {
            enemyHP = Gr3.health;
            enemyAS = Gr3.speed;
            enemyAD = Gr3.strenght;
            ogEH = Gr3.health;
        }

        if (isEnemy4 == true)
        {
            enemyHP = Gr4.health;
            enemyAS = Gr4.speed;
            enemyAD = Gr4.strenght;
            ogEH = Gr4.health;
        }

        if (isSIH1 == true)
        {
            enemyHP = S1.health;
            enemyAS = S1.speed;
            enemyAD = S1.strenght;
            ogEH = S1.health;
        }

        if (isEnemy5 == true)
        {
            enemyHP = Ic.health;
            enemyAS = Ic.speed;
            enemyAD = Ic.strenght;
            ogEH = Ic.health;
        }

        if (isEnemy6 == true)
        {
            enemyHP = Ic2.health;
            enemyAS = Ic2.speed;
            enemyAD = Ic2.strenght;
            ogEH = Ic2.health;
        }

        if (isEnemy7 == true)
        {
            enemyHP = Ic3.health;
            enemyAS = Ic3.speed;
            enemyAD = Ic3.strenght;
            ogEH = Ic3.health;
        }

        if (isEnemy8 == true)
        {
            enemyHP = Ic4.health;
            enemyAS = Ic4.speed;
            enemyAD = Ic4.strenght;
            ogEH = Ic4.health;
        }

        if (isSIH2 == true)
        {
            enemyHP = S2.health;
            enemyAS = S2.speed;
            enemyAD = S2.strenght;
            ogEH = S2.health;
        }

        if (isEnemy9 == true)
        {
            enemyHP = De.health;
            enemyAS = De.speed;
            enemyAD = De.strenght;
            ogEH = De.health;
        }

        if (isEnemy10 == true)
        {
            enemyHP = De2.health;
            enemyAS = De2.speed;
            enemyAD = De2.strenght;
            ogEH = De2.health;
        }

        if (isEnemy11 == true)
        {
            enemyHP = De3.health;
            enemyAS = De3.speed;
            enemyAD = De3.strenght;
            ogEH = De3.health;
        }

        if (isEnemy12 == true)
        {
            enemyHP = De4.health;
            enemyAS = De4.speed;
            enemyAD = De4.strenght;
            ogEH = De4.health;
        }

        if (isSIH3 == true)
        {
            enemyHP = S3.health;
            enemyAS = S3.speed;
            enemyAD = S3.strenght;
            ogEH = S3.health;
        }

        if (isEnemy13 == true)
        {
            enemyHP = Mo1.health;
            enemyAS = Mo1.speed;
            enemyAD = Mo1.strenght;
            ogEH = Mo1.health;
        }

        if (isEnemy14 == true)
        {
            enemyHP = Mo2.health;
            enemyAS = Mo2.speed;
            enemyAD = Mo2.strenght;
            ogEH = Mo2.health;
        }

        if (isEnemy15 == true)
        {
            enemyHP = Mo3.health;
            enemyAS = Mo3.speed;
            enemyAD = Mo3.strenght;
            ogEH = Mo3.health;
        }

        if (isEnemy16 == true)
        {
            enemyHP = Mo4.health;
            enemyAS = Mo4.speed;
            enemyAD = Mo4.strenght;
            ogEH = Mo4.health;
        }

        if (isSIH4 == true)
        {
            enemyHP = S4.health;
            enemyAS = S4.speed;
            enemyAD = S4.strenght;
            ogEH = S4.health;
        }
    }

    public void Stop()
    {
        battlePanel.SetActive(false);
        Mo.inAction = false;
        isAttacking = false;
        St.health = St.fullHealth;

        isEnemy1 = false;
        isEnemy2 = false;
        isEnemy3 = false;
        isEnemy4 = false;
        isEnemy5 = false;
        isEnemy6 = false;
        isEnemy7 = false;
        isEnemy8 = false;
        isEnemy9 = false;
        isEnemy10 = false;
        isEnemy11 = false;
        isEnemy12 = false;
        isEnemy13 = false;
        isEnemy14 = false;
        isEnemy15 = false;
        isEnemy16 = false;

        isSIH1 = false;
        isSIH2 = false;
        isSIH3 = false;
        isSIH4 = false;
    }

    IEnumerator BattleOver()
    {
        yield return new WaitForSeconds(1);
        eIconK1.SetActive(false);
        eIconK2.SetActive(false);
        eIconK3.SetActive(false);
        eIconK4.SetActive(false);
        eIconSIH1.SetActive(false);
        eIconSIH2.SetActive(false);
        eIconSIH3.SetActive(false);
        eIconSIH4.SetActive(false);
        losePanel.SetActive(false);
        battlePanel.SetActive(false);
        isAttacking = false;
        Mo.inAction = false;
        St.health = St.fullHealth;
        xpGivenText.SetActive(false);

        
    }

    IEnumerator PlayerDead()
    {
        if (isEnemy1 == true || isEnemy2 == true || isEnemy3 == true || isEnemy4 == true)
        {
            eIconK1.SetActive(false);
            isEnemy1 = false;
            isEnemy2 = false;
            isEnemy3 = false;
            isEnemy4 = false;
        }

        if (isEnemy13 == true || isEnemy14 == true || isEnemy15 == true || isEnemy16 == true)
        {
            eIconK2.SetActive(false);
            isEnemy13 = false;
            isEnemy14 = false;
            isEnemy15 = false;
            isEnemy16 = false;
        }

        if (isEnemy9 == true || isEnemy10 == true || isEnemy11 == true || isEnemy12 == true)
        {
            eIconK3.SetActive(false);
            isEnemy9 = false;
            isEnemy10 = false;
            isEnemy11 = false;
            isEnemy12 = false;
        }

        if (isEnemy5 == true || isEnemy6 == true || isEnemy7 == true || isEnemy8 == true)
        {
            eIconK4.SetActive(false);
            isEnemy5 = false;
            isEnemy6 = false;
            isEnemy7 = false;
            isEnemy8 = false;
        }

        if (isSIH1 == true)
        {
            eIconSIH1.SetActive(false);
            isSIH1 = false;
        }

        if (isSIH2 == true)
        {
            eIconSIH2.SetActive(false);
            isSIH2 = false;
        }

        if (isSIH3 == true)
        {
            eIconSIH3.SetActive(false);
            isSIH3 = false;
        }

        if (isSIH4 == true)
        {
            eIconSIH4.SetActive(false);
            isSIH4 = false;
        }

        losePanel.SetActive(true);
        yield return new WaitForSeconds(2);
        StartCoroutine(BattleOver());
    }

    IEnumerator EnemyDead()
    {
        xpGiven.text = ogEH + "xp earned";

        if (isEnemy1 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Gr.isFightable = false;
            isEnemy1 = false;
            e1D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy2 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Gr2.isFightable = false;
            isEnemy2 = false;
            e2D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy3 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Gr3.isFightable = false;
            isEnemy3 = false;
            e3D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy4 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Gr4.isFightable = false;
            isEnemy4 = false;
            e4D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isSIH1 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            S1.isFightable = false;
            isSIH1 = false;
            SIH1D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy5 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Ic.isFightable = false;
            isEnemy5 = false;
            e5D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy6 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Ic2.isFightable = false;
            isEnemy6 = false;
            e6D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy7 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Ic3.isFightable = false;
            isEnemy7 = false;
            e7D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy8 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Ic4.isFightable = false;
            isEnemy8 = false;
            e8D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isSIH2 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            S2.isFightable = false;
            isSIH2 = false;
            SIH2D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy9 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            De.isFightable = false;
            isEnemy9 = false;
            e9D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy10 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            De2.isFightable = false;
            isEnemy10 = false;
            e10D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy11 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            De3.isFightable = false;
            isEnemy11 = false;
            e11D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy12 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            De4.isFightable = false;
            isEnemy12 = false;
            e12D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isSIH3 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            S3.isFightable = false;
            isSIH3 = false;
            SIH3D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy13 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Mo1.isFightable = false;
            isEnemy13 = false;
            e13D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy14 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Mo2.isFightable = false;
            isEnemy14 = false;
            e14D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy15 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Mo3.isFightable = false;
            isEnemy15 = false;
            e15D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isEnemy16 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            Mo4.isFightable = false;
            isEnemy16 = false;
            e16D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

        if (isSIH4 == true)
        {
            xpGivenText.SetActive(true);
            coinsGiven.enabled = true;
            coinsGiven.text = St.coinsAfter.ToString() + " coins";
            St.coins += St.coinsAfter;
            S4.isFightable = false;
            isSIH4 = false;
            SIH4D = true;
            yield return new WaitForSeconds(1);
            xpGivenText.SetActive(false);
            coinsGiven.enabled = false;
            StartCoroutine(BattleOver());
            GiveXp();
        }

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

        if (enemyHP <= 0 && isEnemy1 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy2 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy3 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy4 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isSIH1 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy5 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy6 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy7 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy8 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isSIH2 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy9 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy10 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy11 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy12 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isSIH3 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy13 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy14 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy15 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isEnemy16 == true)
        {
            StartCoroutine(EnemyDead());
        }

        if (enemyHP <= 0 && isSIH4 == true)
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
        if (St.realSpeed >= enemyAS)
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
        }
        
    }

    IEnumerator Attack2()
    {
        if (St.realSpeed2 >= enemyAS)
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
        }
    }

    IEnumerator AttackE()
    {
        if (St.realSpeedE >= enemyAS)
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
        }
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
