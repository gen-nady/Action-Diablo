using UnityEngine;

namespace EnemiesSystem.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private float _lifePoints;
        [SerializeField] private float _attackPower;
        
        #region MONO
        private void OnTriggerEnter2D(Collider2D col)
        {
            // if (col.TryGetComponent<Attack>(out var attack))
            // {
            //     _lifePoints -= attack.Damage;
            //     if (_lifePoints <= 0)
            //     {
            //         gameObject.SetActive(false);
            //     }
            // }
        }
        #endregion        
          
        public abstract void TakeDamage();
        
    }
}