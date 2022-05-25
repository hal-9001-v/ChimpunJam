using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainEffect : ItemEffect
{
    [Header("Settings")]
    [SerializeField] [Range(1, 30)] float _dashSpeed;
    [SerializeField] [Range(0.1f, 2)] float _dashDuration;

    CharacterMovementController _characterMovement => FindObjectOfType<CharacterMovementController>();
    public override void ApplyEffect()
    {
        if (_characterMovement)
        {
            _characterMovement.Dash(_dashDuration, _dashSpeed);
        }
    }

}
