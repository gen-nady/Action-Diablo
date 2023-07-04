using UnityEngine;

namespace AttackSystem
{
    public class SimpleAttack : MonoBehaviour, IAttackble
    {
        [SerializeField] private Animator _animator;
        private readonly int _simpleAttack = Animator.StringToHash("SimpleAttack");

        public void Attack()
        {
            _animator.SetTrigger(_simpleAttack);
        }
    }
}