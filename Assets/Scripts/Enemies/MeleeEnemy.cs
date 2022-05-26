using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Hurter))]
public class MeleeEnemy : Enemy
{
    [Header("Settings")] [SerializeField] [Range(1, 20)]
    float _speed = 10;

    [SerializeField] [Range(0.5f, 5)] float _attackRange = 1;

    [SerializeField] [Range(0.1f, 1)] float _attackPreparationTime;
    [SerializeField] [Range(0.1f, 1)] float _attackDuration;
    [SerializeField] [Range(0.1f, 1)] float _afterAttackTime;

    [Header("References")] 
    [SerializeField] private VFXPlayer _confettiVFX;
    private Health _health => GetComponent<Health>();
    private Hurter _melee => GetComponent<Hurter>();


    EnemyTarget _target => FindObjectOfType<EnemyTarget>();

    protected RagdollMaker _ragdollMaker => GetComponentInChildren<RagdollMaker>();

    bool _isAttacking;
    Coroutine _attackCoroutine;

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
        yield return new WaitForSeconds(_attackPreparationTime);


        _melee.EnableAttackColliders(true);
        yield return new WaitForSeconds(_attackDuration);
        _melee.EnableAttackColliders(false);


        yield return new WaitForSeconds(_afterAttackTime);

        _isAttacking = false;
    }
    
    void Hurt(Vector3 source, float push, Transform hitter)
    {
        //Oof
    }

    void Die(Vector3 source, float push, Transform hitter)
    {
        //Destroy(gameObject);
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