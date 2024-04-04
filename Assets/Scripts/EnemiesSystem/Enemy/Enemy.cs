using ItemsSystem.Items.World;
using UnityEngine;

namespace EnemiesSystem.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private float _lifePoints;
        [SerializeField] private float _attackPower;
        [SerializeField] private float _forceRebound;
        
        private Rigidbody _rb;
        private Transform _tr;
        
        #region MONO

        private void OnEnable()
        {
            _rb = GetComponent<Rigidbody>();
            _tr = GetComponent<Transform>();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.TryGetComponent<SimpleSword>(out var attack))
            {
                if(attack.Info.StatsAttackInfo == null) return;
                _lifePoints -= attack.Info.StatsAttackInfo.Damage;
                TakeDamage();
                SetRebound(col);
                if (_lifePoints <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        #endregion        
          
        protected abstract void TakeDamage();

        private void SetRebound(Collider col)
        {
            var direction = (_tr.position - col.bounds.center).normalized;
            direction *= _forceRebound;
            _rb.AddForce(direction, ForceMode.Impulse);
        }
    }
}