using System;
using System.Collections;
using System.Collections.Generic;
using AttackSystem;
using AttackSystem.AnimatorState;
using UnityEngine;

public class SwordAttack : StateMachineBehaviour
{
    [SerializeField] private SwordsAttack _currentSwordsAttack;
    private ComboSwordAttack _comboSwordAttack;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _comboSwordAttack = animator.GetComponent<ComboSwordAttack>();
        switch (_currentSwordsAttack)
        {
            case SwordsAttack.FirstSwordAttack:
                _comboSwordAttack.ChangeState(SwordsAttack.FirstSwordAttack);
                break;
            case SwordsAttack.SecondSwordAttack:
                _comboSwordAttack.ChangeState(SwordsAttack.SecondSwordAttack);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _comboSwordAttack.ChangeState(SwordsAttack.None);
    }
}
