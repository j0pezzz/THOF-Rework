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
    public int realSpeed;
    public int realStrenght;
    public int realSpeed2;
    public int realStrenght2;
    public int realSpeedE;
    public int realStrenghtE;
    public int realHealingE;
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

    public string weaponName1;
    public string weaponName2;
    public string weaponNameE;

    public Text hp;
    public Text coinAmount;

    PlayerController move;


    // Start is called before the first frame update
    void Start()
    {
        weaponName1 = "Eagle punch";
        weaponName2 = "Eagle kick";
        weaponNameE = "Matchstick";
        hp.text = health.ToString();

        move = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        health = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
        Skillpointsneeded();
        CardCollection();
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

    void CardCollection()
    {
        if (weaponName1 == "Eagle punch")
        {
            realSpeed = speed + 3;
            realStrenght = strenght + 3;
        }

        if (weaponName2 == "Eagle punch")
        {
            realSpeed2 = speed + 3;
            realStrenght2 = strenght + 3;
        }

        if (weaponName1 == "Eagle kick")
        {
            realSpeed = speed + 7;
            realStrenght = strenght + 2;
        }

        if (weaponName2 == "Eagle kick")
        {
            realSpeed2 = speed + 7;
            realStrenght2 = strenght + 2;
        }

        if (weaponNameE == "Matchstick")
        {
            realSpeedE = speed + 6;
            realStrenghtE = strenght + 2;
            realHealingE = 0;
        }

        if (weaponNameE == "Sandcastle")
        {
            realSpeedE = speed + 2;
            realStrenghtE = strenght + 4;
            realHealingE = 0;
        }

        if (weaponNameE == "Phone charger")
        {
            realSpeedE = speed + 8;
            realStrenghtE = strenght + 1;
            realHealingE = healing + 1;
        }

        if (weaponNameE == "Water gun")
        {
            realSpeedE = speed + 4;
            realStrenghtE = strenght + 3;
            realHealingE = 0;
        }

        if (weaponNameE == "Weed Blade")
        {
            realSpeedE = speed + 1;
            realStrenghtE = strenght + 3;
            realHealingE = 0;
        }

        if(weaponNameE == "Electroshock")
        {
            realSpeedE = speed + 8;
            realStrenghtE = strenght + 4;
            realHealingE = 0;
        }

        if(weaponNameE == "Snowball")
        {
            realSpeedE = speed + 8;
            realStrenghtE = strenght + 2;
            realHealingE = healing + 2;
        }

        if(weaponNameE == "Lil Arson")
        {
            realSpeedE = speed + 4;
            realStrenghtE = strenght + 4;
            realHealingE = 0;
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
            if (_instance == null) _instance = FindAnyObjectByType<Stats>();
            return _instance;
        }
    }
}
