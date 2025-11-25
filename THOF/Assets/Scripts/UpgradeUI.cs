using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillPointsText;
    [SerializeField] private TextMeshProUGUI xpText;
    [SerializeField] private TextMeshProUGUI healthSkillPointText;
    [SerializeField] private TextMeshProUGUI speedSkillPointText;
    [SerializeField] private TextMeshProUGUI strengthSkillPointText;
    [SerializeField] private TextMeshProUGUI healingSkillPointText;

    void Start() => UpdateUpgrades();

    void UpdateUpgrades()
    {
        skillPointsText.SetText($"SKILL POINTS: {Stats.Instance.GetSkillPoints()}");
        xpText.SetText($"{Stats.Instance.xp}/{Stats.Instance.ofWhatXp} XP");
        healthSkillPointText.SetText($"{Stats.Instance.bonusHealth}/20 Health ({Stats.Instance.GetHealthSkillPointsNeeded()})");
        speedSkillPointText.SetText($"{Stats.Instance.speed}/20 Speed ({Stats.Instance.GetSpeedSkillPointsNeeded()})");
        strengthSkillPointText.SetText($"{Stats.Instance.strenght}/20 Strength ({Stats.Instance.GetStrengthSkillPointsNeeded()})");
        healingSkillPointText.SetText($"{Stats.Instance.healing}/20 Healing ({Stats.Instance.GetHealingSkillPointsNeeded()})");
    }

    public void UpgradeHealth()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetHealthSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeHealth();
        UpdateUpgrades();
    }

    public void UpgradeSpeed()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetSpeedSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeSpeed();
        UpdateUpgrades();
    }

    public void UpgradeStrength()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetStrengthSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeStrength();
        UpdateUpgrades();
    }

    public void UpgradeHealing()
    {
        if (Stats.Instance.GetSkillPoints() < Stats.Instance.GetHealingSkillPointsNeeded()) return;
        
        Stats.Instance.UpgradeHealing();
        UpdateUpgrades();
    }
}
