using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimator : MonoBehaviour
{

    [SerializeField] private Animator _animatorc;
    private static readonly int Die = Animator.StringToHash("Die");

    public void PlayDead()
    {
        _animatorc.SetTrigger(Die);
    }
}
