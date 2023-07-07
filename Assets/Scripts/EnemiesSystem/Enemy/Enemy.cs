using ItemsSystem.Items.World;
using UnityEngine;

namespace EnemiesSystem.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private float _lifePoints;
        [SerializeField] private float _attackPower;
        
        #region MONO
        private void OnTriggerEnter(Collider col)
        {
            if (col.TryGetComponent<SimpleSword>(out var attack))
            {
                if(attack.Info.StatsAttackInfo == null) return;
                _lifePoints -= attack.Info.StatsAttackInfo.Damage;
                if (_lifePoints <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        #endregion        
          
        public abstract void TakeDamage();
        
    }
}