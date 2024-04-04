using AttackSystem.AnimatorState;
using UnityEngine;

namespace AttackSystem
{
    public class ComboSwordAttack : MonoBehaviour, IAttackble
    {
        [SerializeField] private Animator _animator;
        private SwordsAttack _currentSwordAttack;
        private readonly int _comboAttackFirst = Animator.StringToHash("ComboAttackFirst");
        private readonly int _comboAttackSecond = Animator.StringToHash("ComboAttackSecond");

        public void Attack()
        {
            switch (_currentSwordAttack)
            {
                case SwordsAttack.None:
                    _animator.SetTrigger(_comboAttackFirst);
                    break;
                case SwordsAttack.FirstSwordAttack:
                    _animator.SetTrigger(_comboAttackSecond);
                    break;
            }
        }

        public void ChangeState(SwordsAttack state)
        {
            _currentSwordAttack = state;
            if (state == SwordsAttack.None)
            {
                _animator.ResetTrigger(_comboAttackFirst);
                _animator.ResetTrigger(_comboAttackSecond);
            }
        }
    }
}