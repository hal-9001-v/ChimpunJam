using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Shooter))]
public class ShooterEnemy : Enemy
{
    [Header("Settings")]
    [SerializeField]
    [Range(1, 20)]
    float _speed = 10;

    [SerializeField] [Range(0.5f, 10)] float _attackRange = 5;

    [SerializeField] [Range(0.1f, 1)] float _shootPreparationTime;

    [SerializeField] [Range(1, 5)] int _shootCount;
    [SerializeField] [Range(0.1f, 1)] float _shootDelay;

    [Header("References")]
    [SerializeField]
    private VFXPlayer _confettiVFX;

    protected RagdollMaker _ragdollMaker => GetComponentInChildren<RagdollMaker>();

    Health _health => GetComponent<Health>();
    Shooter _shooter => GetComponent<Shooter>();
    EnemyTarget _target => FindObjectOfType<EnemyTarget>();

    Coroutine _attackCoroutine;

    bool _isAttacking;

    private void Awake()
    {
        _confettiVFX.StopVFX();
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
            else
            {
                var direction = _target.transform.position - transform.position;
                direction.y = 0;
                direction.Normalize();

                transform.forward = Vector3.Lerp(transform.forward, direction, 0.5f);
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
            _rigidBody.velocity = Vector3.zero;
        }
    }

    public bool IsAttacking()
    {
        return _isAttacking;
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
        StartCoroutine(DieC());
    }

    IEnumerator DieC()
    {
        _ragdollMaker.EnableRagdoll(true);
        yield return new WaitForSeconds(3f);
        _confettiVFX.transform.parent = null;
        _confettiVFX.EnableVFX();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}