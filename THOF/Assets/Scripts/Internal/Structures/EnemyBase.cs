using Internal.Enums;
using UnityEngine;

namespace Internal.Structures
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public bool IsFightable = true;
        public int Health;
        public int Speed;
        public int Strength;
        public BoxCollider2D Collider;
        public EnemyType EnemyType;
        public int EnemyIndex;
        public Sprite EnemySprite;

        public abstract void CheckEnemyFightStatus();
    }
}