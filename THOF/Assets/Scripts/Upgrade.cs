using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    moving Mo;
    Stats St;

    public Text skillpoints;
    public Text xp;
    public Text healthSp;
    public Text speedSp;
    public Text strenghtSp;
    public Text healingSp;

    // Start is called before the first frame update
    void Start()
    {
        Mo = GameObject.Find("Player").GetComponent<moving>();
        St = GameObject.Find("Player").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        TextThingie();
    }

    void TextThingie()
    {
        skillpoints.text = "Skillpoints: " + St.skillPoints.ToString();
        xp.text = St.xp + "/" + St.ofWhatXp + " XP";
        healthSp.text = St.bonusHealth + "/20 " + "Health (" + St.healthSPN.ToString() + ")";
        speedSp.text = St.speed + "/20 " + "Speed (" + St.speedSPN.ToString() + ")";
        strenghtSp.text = St.strenght + "/20 " + "Strenght (" + St.strenghtSPN.ToString() + ")";
        healingSp.text = St.healing + "/20 " + "Healing (" + St.healingSPN.ToString() + ")";
    }

    public void Health()
    {
        if (St.skillPoints >= St.healthSPN)
        {
            St.skillPoints -= St.healthSPN;
            St.bonusHealth++;
            St.fullHealth++;
        }
    }

    public void Speed()
    {
        if (St.skillPoints >= St.speedSPN)
        {
            St.skillPoints -= St.speedSPN;
            St.speed++;
        }
    }

    public void Strenght()
    {
        if (St.skillPoints >= St.strenghtSPN)
        {
            St.skillPoints -= St.strenghtSPN;
            St.strenght++;
        }
    }

    public void Healing()
    {
        if (St.skillPoints >= St.healingSPN)
        {
            St.skillPoints -= St.healingSPN;
            St.healing++;
        }
    }
}
