using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimatorController : MonoBehaviour
{
    private Animator _animator => GetComponentInChildren<Animator>();
    private CharacterMovementController _characterMovement => GetComponentInParent<CharacterMovementController>();
    private const string _idleState = "Idle";
    private const string _walkState = "Walk";
    private void Awake()
    {
        _animator.Play(_idleState);
    }

    private void Update()
    {
        _animator.Play(_characterMovement.GetVelocity().magnitude > 0.1f ? _walkState : _idleState);
    }
}