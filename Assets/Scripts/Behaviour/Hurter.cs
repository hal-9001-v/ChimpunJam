using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class Hurter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] HealthTag _targetTag;
    public HealthTag targetTag { get { return _targetTag; } }

    [Header("References")]
    [SerializeField] Collider[] _attackColliders;

    // Cuando colidee cosa de melee con cosa de health se llama a hurt()
    [Header("Hit Values")]
    [SerializeField] [Range(0, 10)] private float _damage;
    [SerializeField] [Range(0, 10)] private float _push;
    public Action hitAction;

    bool _collidersActive = true;


    private void Awake()
    {
        if (_attackColliders == null || _attackColliders.Length == 0)
        {
            _attackColliders = GetComponentsInChildren<Collider>();
        }

        EnableAttackColliders(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(transform, other, transform.position);
    }

    private void Hit(Transform source, Collider coll, Vector3 pos)
    {
        var health = coll.GetComponent<Health>();
        if (health && health.healthTag == _targetTag)
        {
            //Debug.Log("HURT");
            health.Hurt(_damage, pos, _push, source);

            if (hitAction != null)
                hitAction.Invoke();

        }
    }

    public void EnableAttackColliders(bool value)
    {
        if (_collidersActive == value) return;

        _collidersActive = value;
        if (_attackColliders != null)
        {
            foreach (var collider in _attackColliders)
            {
                collider.enabled = value;
            }
        }
    }

}
