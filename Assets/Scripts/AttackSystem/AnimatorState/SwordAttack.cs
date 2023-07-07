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
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
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

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _comboSwordAttack.ChangeState(SwordsAttack.None);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
