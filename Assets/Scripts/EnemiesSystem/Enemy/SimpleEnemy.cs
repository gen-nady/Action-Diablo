using DG.Tweening;
using UnityEngine;

namespace EnemiesSystem.Enemy
{
    public class SimpleEnemy : Enemy
    {
        [SerializeField] private Transform _transform;
        
        protected override void TakeDamage()
        {
            _transform.DOScale(5f, 0.1f).SetLoops(2, LoopType.Yoyo);
        }
    }
}