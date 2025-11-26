using Internal.Structures;
using UnityEngine;

public class Enemy : EnemyBase
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        CheckEnemyFightStatus();
        
        Dialog.Instance.SetEnemyIcon(EnemySprite);
        Battle.Instance.SetEnemy(this);
        UIReferences.Instance.ShowInteract(true);
        PlayerController.Instance.EnemyRadius(true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        UIReferences.Instance?.ShowInteract(false);
        PlayerController.Instance?.EnemyRadius(false);
    }
}
