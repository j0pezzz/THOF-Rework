using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int fullHealth = 10;
    public int health;
    public int bonusHealth;
    public int speed = 0;
    public int strenght = 0;
    public int healing = 0;
    public int level = 1;
    public int xp = 0;
    public int ofWhatXp = 10;
    public int skillPoints = 0;
    public int coins = 0;
    public int coinsAfter = 50;
    public int healthSPN;
    public int speedSPN;
    public int strenghtSPN;
    public int healingSPN;

    public Text hp;
    public Text coinAmount;

    public List<ShopItem> items = new();
    public List<ShopItem> equippedItems = new();

    void Start()
    {
        equippedItems = new List<ShopItem>(GameData.Instance.startingItems);

        health = fullHealth;
        hp.text = health.ToString();
    }

    void Update()
    {
        LevelUp();
        Skillpointsneeded();
        NegativeHealth();
        hp.text = health.ToString();
        coinAmount.text = coins.ToString();
    }

    public void SetData()
    {
        
    }

    public void LevelUp()
    {
        if (xp >= ofWhatXp)
        {
            level++;
            xp = xp -= ofWhatXp;
            ofWhatXp += 5;
            skillPoints += 1;
            fullHealth += 2;
        }
    }

    public void Skillpointsneeded()
    {
        if (healing < 2)
        {
            healingSPN = 1;
        }

        if (healing > 2 && healing <= 3)
        {
            healingSPN = 2;
        }

        if (healing > 3 && healing <= 5)
        {
            healingSPN = 3;
        }

        if (healing > 5 && healing <= 8)
        {
            healingSPN = 4;
        }

        if (healing > 8)
        {
            healingSPN = 50;
        }

        if (speed < 2.5f)
        {
            speedSPN = 1;
        }

        if (speed > 2.5f && speed < 5)
        {
            speedSPN = 2;
        }

        if (speed > 5 && speed < 7.5f)
        {
            speedSPN = 3;
        }

        if (speed > 7.5f && speed < 10)
        {
            speedSPN = 4;
        }

        if (speed > 10)
        {
            speedSPN = 50;
        }

        if (strenght < 2.5f)
        {
            strenghtSPN = 1;
        }

        if (strenght > 2.5f && strenght < 5)
        {
            strenghtSPN = 2;
        }

        if (strenght > 5 && strenght < 7.5f)
        {
            strenghtSPN = 3;
        }

        if (strenght > 7.5f && strenght < 10)
        {
            strenghtSPN = 4;
        }

        if (strenght > 10)
        {
            strenghtSPN = 50;
        }

        if (bonusHealth < 2.5f)
        {
            healthSPN = 1;
        }

        if (bonusHealth > 2.5f && bonusHealth < 5)
        {
            healthSPN = 2;
        }

        if (bonusHealth > 5 && bonusHealth < 7.5f)
        {
            healthSPN = 3;
        }

        if (bonusHealth > 7.5f && bonusHealth < 10)
        {
            healthSPN = 4;
        }

        if (bonusHealth > 10)
        {
            healthSPN = 50;
        }
    }

    void NegativeHealth()
    {
        if (health < 0)
        {
            health = 0;
        }
    }

    private static Stats _instance;
    public static Stats Instance
    {
        get
        {
            if (!_instance) _instance = FindAnyObjectByType<Stats>();
            return _instance;
        }
    }
}
