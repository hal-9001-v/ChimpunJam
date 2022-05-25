using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Navigator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Collider[] _colliders;
    protected Navigator _navigator => GetComponent<Navigator>();
    protected Rigidbody _rigidBody => GetComponent<Rigidbody>();
    public Health health => GetComponent<Health>();
    
    public void EnableEnemy()
    {
        _navigator.EnableNavigator();

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = true;
        }

        foreach (Collider collider in _colliders)
        {
            collider.enabled = true;
        }

        _rigidBody.useGravity = true;
    }

    public void DisableEnemy()
    {
        _navigator.DisableNavigator();

        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }

        foreach (Collider collider in _colliders)
        {
            collider.enabled = false;
        }

        _rigidBody.useGravity = false;
    }




}