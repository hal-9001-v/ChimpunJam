using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class FrenchRobotEffect : ItemEffect
{
    [SerializeField] Animator _animator;
    Shooter _shooter => GetComponent<Shooter>();
    CharaterInputComponent _input;

    Vector3 _previousPosition;

    const string ShootTriggerKey = "Shoot";
    const string WalingBoolKey = "Walking";

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

    private void FixedUpdate()
    {
        var direction = transform.position - _previousPosition;
        if (direction.sqrMagnitude >= 0.1f)
        {
            _animator.SetBool(WalingBoolKey, true);

            direction.Normalize();

        }
        else
        {
            _animator.SetBool(WalingBoolKey, false);
        }

        _previousPosition = transform.position;
    }



}
