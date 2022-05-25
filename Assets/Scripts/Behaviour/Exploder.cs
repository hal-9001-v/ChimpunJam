using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hurter))]
[RequireComponent(typeof(SphereCollider))]

public class Exploder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [Range(0.1f, 0.5f)] float _explosionDuration;

    Coroutine _explosionCoroutine;
    Hurter _melee => GetComponent<Hurter>();

    private void Awake()
    {
        _melee.EnableAttackColliders(false);

    }

    public void Explode()
    {
        _explosionCoroutine = StartCoroutine(Explosion());

    }
    IEnumerator Explosion()
    {
        _melee.EnableAttackColliders(true);
        yield return new WaitForSeconds(_explosionDuration);
        _melee.EnableAttackColliders(false);

    }
}
