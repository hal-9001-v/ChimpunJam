using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementDetector))]
public class BabyDuckEffect : ItemEffect
{
    [Header("References")]
    [SerializeField] Animator _animator;

    MovementDetector _movementDetector => GetComponent<MovementDetector>();

    const string WalkinBoolKey = "Walking";

    public override void ApplyEffect()
    {
        //Quack
    }

    private void Update()
    {
        if (_movementDetector.isMoving)
        {
            _animator.SetBool(WalkinBoolKey, true);
        }
        else
        {
            _animator.SetBool(WalkinBoolKey, false);
        }
    }
}
