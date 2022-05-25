using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Shooter))]
public class ShooterEnemy : Enemy
{
    [Header("Settings")]
    [SerializeField] [Range(1, 20)] float _speed = 10;
    [SerializeField] [Range(0.5f, 10)] float _attackRange = 5;

    [SerializeField] [Range(0.1f, 1)] float _shootPreparationTime;

    [SerializeField] [Range(1, 5)] int _shootCount;
    [SerializeField] [Range(0.1f, 1)] float _shootDelay;


    Health _health => GetComponent<Health>();
    Shooter _shooter => GetComponent<Shooter>();
    EnemyTarget _target => FindObjectOfType<EnemyTarget>();

    Coroutine _attackCoroutine;

    bool _isAttacking;

    private void Awake()
    {
        _health.hurtAction += Hurt;
        _health.deadAction += Die;
    }

    void FixedUpdate()
    {
        if (_target)
        {
            if (!_isAttacking)
            {
                _navigator.GoToPosition(_speed, _target.transform.position);

                if (Vector3.Distance(transform.position, _target.transform.position) < _attackRange)
                {
                    Attack();
                }
            }

        }
    }

    void Attack()
    {
        if (!_isAttacking)
        {
            _isAttacking = true;

            _navigator.Stop();
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }


    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(_shootPreparationTime);
        for (int i = 0; i < _shootCount; i++)
        {
            _shooter.ShootToTarget(_target.transform);
            yield return new WaitForSeconds(_shootDelay);
        }

        _isAttacking = false;

    }

    void Hurt(Vector3 source, float push, Transform hitter)
    {
        //Oof
    }

    void Die(Vector3 source, float push, Transform hitter)
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }


}
