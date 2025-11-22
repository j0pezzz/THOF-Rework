using Internal.Structures;
using UnityEngine;

public class Enemy : EnemyBase
{
    public override void CheckEnemyFightStatus()
    {
        Debug.Log($"Enemy can be fought: {IsFightable}");
        Collider.enabled = IsFightable;
    }
}
