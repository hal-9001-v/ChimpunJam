using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaccoonAnimationController : MonoBehaviour
{
    private Animator _animator => GetComponentInChildren<Animator>();
    private ShooterEnemy _shooterAI => GetComponentInParent<ShooterEnemy>();

    private void Update()
    {
        if (_shooterAI.IsAttacking())
        {
            _animator.SetTrigger("Attack");
        }
        else
        {
            _animator.ResetTrigger(("Attack"));
            _animator.Play("Walk");
        }


    }
}
