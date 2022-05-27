using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementDetector))]
public class GnomeEffect : ItemEffect
{
    [Header("References")]
    [SerializeField] Animator _mockupAnimator;
    [Space(5)]
    [SerializeField] Animator _explosiveAnimator;
    [SerializeField] FollowObject _gnomeFollow;
    [SerializeField] Exploder _gnomeExploder;
    [SerializeField] Hider _gnomeHider;

    [Header("Settings")]
    [SerializeField] [Range(0.5f, 4)] float _defaultRandomDistance;
    [SerializeField] [Range(1, 5)] float _timeUntilExplosion;

    MovementDetector _movementDetector => GetComponent<MovementDetector>();

    Transform target;

    Vector3 _deploymentRandomPosition;

    Coroutine _countdownCoroutine;

    const string WalkingBoolKey = "Walking";

    private void Awake()
    {
        _explosiveAnimator.SetBool(WalkingBoolKey, true);

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

    private void Update()
    {
        if (_movementDetector.isMoving)
        {
            _mockupAnimator.SetBool(WalkingBoolKey, true);
        }
        else
        {
            _mockupAnimator.SetBool(WalkingBoolKey, false);
        }
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
