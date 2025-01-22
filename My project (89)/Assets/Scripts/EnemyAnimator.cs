using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Move = Animator.StringToHash("IsMoving");

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void IsMoving(bool condition)
    {
        _animator.SetBool(Move, condition);
    }
}
