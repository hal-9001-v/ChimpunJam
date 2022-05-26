using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeEffect : ItemEffect
{
    [Header("Settings")]
    [SerializeField] [Range(0.5f, 4)] float _defaultRandomDistance;
    [SerializeField][Range(1, 5)] float _timeUntilExplosion;

    [SerializeField] FollowObject _gnomeFollow;
    [SerializeField] Exploder _gnomeExploder;
    [SerializeField] Hider _gnomeHider;


    Transform target;

    Vector3 _deploymentRandomPosition;

    Coroutine _countdownCoroutine;

    private void Awake()
    {
        _gnomeHider.Show(false);
        _gnomeFollow.stopFollowing = true;
    }

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
            target = closestEnemy.transform;
        }
        else
        {
            target = null;

            var randomOffset = (Random.Range(-1, 1) * transform.forward + Random.Range(-1, 1) * transform.right).normalized * _defaultRandomDistance;
            _deploymentRandomPosition = transform.position + randomOffset;
        }

        _gnomeFollow.SetTarget(target);
        _gnomeHider.Show(true);
        _gnomeFollow.stopFollowing = false;

        _gnomeFollow.transform.position = transform.position;
        _gnomeFollow.transform.parent = null;

        if (_countdownCoroutine != null)
        {
            StopCoroutine(ExplosionCountdown());
        }

        _countdownCoroutine = StartCoroutine(ExplosionCountdown());
    }

    IEnumerator ExplosionCountdown()
    {
        yield return new WaitForSeconds(_timeUntilExplosion);
        _gnomeExploder.Explode();
        _gnomeHider.Show(false);

       _gnomeFollow.transform.position = transform.position;
       _gnomeFollow.transform.parent = transform;
       _gnomeFollow.stopFollowing = true;
    }



}
