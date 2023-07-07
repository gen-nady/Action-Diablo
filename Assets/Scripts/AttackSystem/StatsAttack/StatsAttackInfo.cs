using UnityEngine;

namespace AttackSystem.StatsAttack
{
    [CreateAssetMenu(fileName = "StatsAttackInfo", menuName = "Inventory/SwordAttack", order = 1)]
    public class StatsAttackInfo : ScriptableObject
    {
        [SerializeField] private int _damage;

        public int Damage => _damage;
    }
}