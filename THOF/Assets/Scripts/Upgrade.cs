using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Text skillpoints;
    public Text xp;
    public Text healthSp;
    public Text speedSp;
    public Text strenghtSp;
    public Text healingSp;

    void UpdateUpgrades()
    {
        skillpoints.text = $"Skillpoints: {Stats.Instance.GetSkillPoints()}";
        xp.text = $"{Stats.Instance.xp}/{Stats.Instance.ofWhatXp} XP";
        healthSp.text = $"{Stats.Instance.bonusHealth}/20 Health ({Stats.Instance.GetHealthSkillPointsNeeded()})";
        speedSp.text = $"{Stats.Instance.speed}/20 Speed ({Stats.Instance.GetSpeedSkillPointsNeeded()}";
        strenghtSp.text = $"{Stats.Instance.strenght}/20 Strength ({Stats.Instance.GetStrengthSkillPointsNeeded()})";
        healingSp.text = $"{Stats.Instance.healing}/20 Healing ({Stats.Instance.GetHealingSkillPointsNeeded()})";
    }

    public void Health()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetHealthSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeHealth();
        UpdateUpgrades();
    }

    public void Speed()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetSpeedSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeSpeed();
        UpdateUpgrades();
    }

    public void Strength()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetStrengthSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeStrength();
    }

    public void Healing()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetHealingSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeHealing();
        UpdateUpgrades();
    }
}
