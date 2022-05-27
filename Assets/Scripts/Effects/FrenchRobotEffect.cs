using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(MovementDetector))]
public class FrenchRobotEffect : ItemEffect
{
    [Header("References")]
    [SerializeField] Animator _animator;

    [Header("Settings")]
    [SerializeField] [Range(0.1f, 1)] float _timeWithNoMove;

    Shooter _shooter => GetComponent<Shooter>();
    MovementDetector _movementDetector => GetComponent<MovementDetector>();

    const string ShootTriggerKey = "Shoot";
    const string WalkingBoolKey = "Walking";

    public override void ApplyEffect()
    {
        var enemies = FindObjectsOfType<Enemy>();
        var closestMagnitude = float.MaxValue;
        Enemy closestEnemy = null;

        _animator.SetTrigger(ShootTriggerKey);

        foreach (var enemy in enemies)
        {
            var newMagnitude = Vector3.Magnitude(enemy.transform.position - transform.position);

            if (newMagnitude < closestMagnitude)
            {
                closestMagnitude = newMagnitude;

                closestEnemy = enemy;
            }
        }

        if (closestEnemy)
        {
            _shooter.ShootToTarget(closestEnemy.transform);
        }
        else
        {
            _shooter.ShootInDirection(transform.forward);
        }

    }

    private void Update()
    {
        if (_movementDetector.isMoving)
        {
            _animator.SetBool(WalkingBoolKey, true);
        }
        else
        {
            _animator.SetBool(WalkingBoolKey, false);
        }
    }



}
