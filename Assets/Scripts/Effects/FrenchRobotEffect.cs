using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class FrenchRobotEffect : ItemEffect
{
    Shooter _shooter => GetComponent<Shooter>();

    public override void ApplyEffect()
    {

        var enemies = FindObjectsOfType<Enemy>();
        var closestMagnitude = float.MaxValue;
        Enemy closestEnemy = null;

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


}
