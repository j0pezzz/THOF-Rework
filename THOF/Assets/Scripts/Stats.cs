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
    public int healthSkillPointsNeeded = 1;
    public int speedSkillPointsNeeded = 1;
    public int strenghtSkillPointsNeeded = 1;
    public int healingSkillPointsNeeded = 1;

    public List<ShopItem> items = new();
    public List<ShopItem> equippedItems = new();

    void Start()
    {
        equippedItems = new List<ShopItem>(GameData.Instance.startingItems);
        
        health = fullHealth;
        UIReferences.Instance.UpdateHealth(fullHealth);
    }

    public void AddCoins()
    {
        coins += coinsAfter;
        UIReferences.Instance.UpdateCoins(coins);
    }

    public void SetCoins(int amount)
    {
        coins = amount;
        UIReferences.Instance.UpdateCoins(coins);
    }

    public void SetHealth(int savedHealth)
    {
        health = savedHealth;
        UIReferences.Instance.UpdateHealth(health);
    }

    void Update()
    {
        LevelUp();
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

    public void UpgradeHealth()
    {
        skillPoints -= healthSkillPointsNeeded;

        bonusHealth++;
        fullHealth++;

        CalculateHealthSkillPointRequirement();
    }

    void CalculateHealthSkillPointRequirement()
    {
        if (bonusHealth < 2.5f)
        {
            healthSkillPointsNeeded = 1;
        }
        else if (bonusHealth < 5f)
        {
            healthSkillPointsNeeded = 2;
        }
        else if (bonusHealth < 7.5f)
        {
            healthSkillPointsNeeded = 3;
        }
        else if (bonusHealth < 10f)
        {
            healthSkillPointsNeeded = 4;
        }
        else
        {
            healthSkillPointsNeeded = 50;
        }
    }

    public void UpgradeSpeed()
    {
        skillPoints -= speedSkillPointsNeeded;
        speed++;

        CalculateSpeedSkillPointRequirement();
    }

    void CalculateSpeedSkillPointRequirement()
    {
        if (speed < 2.5f)
        {
            speedSkillPointsNeeded = 1;
        }
        else if (speed < 5)
        {
            speedSkillPointsNeeded = 2;
        }
        else if (speed < 7.5f)
        {
            speedSkillPointsNeeded = 3;
        }
        else if (speed < 10)
        {
            speedSkillPointsNeeded = 4;
        }
        else
        {
            speedSkillPointsNeeded = 50;
        }
    }

    public void UpgradeStrength()
    {
        skillPoints -= strenghtSkillPointsNeeded;
        strenght++;

        CalculateStrengthSkillPointRequirement();
    }

    void CalculateStrengthSkillPointRequirement()
    {
        if (strenght < 2.5f)
        {
            strenghtSkillPointsNeeded = 1;
        }
        else if (strenght < 5)
        {
            strenghtSkillPointsNeeded = 2;
        }
        else if (strenght < 7.5f)
        {
            strenghtSkillPointsNeeded = 3;
        }
        else if (strenght < 10)
        {
            strenghtSkillPointsNeeded = 4;
        }
        else
        {
            strenghtSkillPointsNeeded = 50;
        }
    }

    public void UpgradeHealing()
    {
        skillPoints -= healingSkillPointsNeeded;
        healing++;
        
        CalculateHealingSkillPointRequirement();
    }

    void CalculateHealingSkillPointRequirement()
    {
        if (healing < 2)
        {
            healingSkillPointsNeeded = 1;
        }
        else if (healing < 3)
        {
            healingSkillPointsNeeded = 2;
        }
        else if (healing < 5)
        {
            healingSkillPointsNeeded = 3;
        }
        else if (healing <= 8)
        {
            healingSkillPointsNeeded = 4;
        }
        else
        {
            healingSkillPointsNeeded = 50;
        }
    }

    public int GetSkillPoints() => skillPoints;

    public int GetHealthSkillPointsNeeded() => healthSkillPointsNeeded;
    public int GetSpeedSkillPointsNeeded() => speedSkillPointsNeeded;
    public int GetStrengthSkillPointsNeeded() => strenghtSkillPointsNeeded;
    public int GetHealingSkillPointsNeeded() => healingSkillPointsNeeded;

    public void AddHealth(int addHealth)
    {
        health = Mathf.Clamp(health + addHealth, 0, fullHealth);
        UIReferences.Instance.UpdateHealth(health);
    }

    public void ReduceHealth(int minusHealth)
    {
        health = Mathf.Clamp(health - minusHealth, 0, fullHealth);
        UIReferences.Instance.UpdateHealth(health);
    }

    //TODO: we need to save all stats and weapons.
    public override string ToString()
    {
        return $"";
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
