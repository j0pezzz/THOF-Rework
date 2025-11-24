using Internal.Structures;

public class Enemy : EnemyBase
{
    public override void CheckEnemyFightStatus()
    {
        Collider.enabled = IsFightable;
    }
}
