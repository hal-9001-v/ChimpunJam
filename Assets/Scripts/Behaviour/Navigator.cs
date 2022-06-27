using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class Navigator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [Range(0.01f, 1)] float _reachingDistance = 0.1f;
    [SerializeField] [Range(0.01f, 10)] float _warpDistance = 1f;
    [SerializeField] [Range(0.1f, 1)] float _refreshTime;


    public Vector3 velocity
    {
        get
        {
            return _navMeshAgent.velocity;
        }
    }

    float _desiredSpeed;

    NavMeshAgent _navMeshAgent => GetComponent<NavMeshAgent>();
    Rigidbody _rigidbody => GetComponent<Rigidbody>();

    Transform _target;
    //Used for an specific position with no changes
    Vector3 _targetPosition;

    float _refreshElapsedTime;

    // Start is called before the first frame update
    void Awake()
    {
        

        _rigidbody.isKinematic = true;


    }

    private void FixedUpdate()
    {
        if (_refreshElapsedTime > _refreshTime)
        {
            _refreshElapsedTime = 0;

            if (_navMeshAgent.isOnNavMesh == false && _navMeshAgent.enabled)
            {
                WarpAgent();
            }

            if (_navMeshAgent.enabled && _navMeshAgent.isOnNavMesh)
                _navMeshAgent.SetDestination(_targetPosition);
        }
        else
        {
            _refreshElapsedTime += Time.fixedDeltaTime;
        }


    }

    public void DisableNavigator()
    {
        _rigidbody.isKinematic = false;

        _navMeshAgent.enabled = false;

        enabled = false;

    }

    public void EnableNavigator()
    {
        _rigidbody.isKinematic = true;

        _navMeshAgent.enabled = true;

        enabled = true;
    }


    public void Pursue(float speed, Transform target)
    {
        _desiredSpeed = speed;
        _navMeshAgent.speed = speed;

        _target = target;

        Continue();
    }

    public void GoToPosition(float speed, Vector3 position)
    {
        _navMeshAgent.speed = speed;

        _targetPosition = position;

        Continue();
    }

    public void Stop()
    {
        if (_navMeshAgent.isOnNavMesh)
            _navMeshAgent.isStopped = true;
    }

    public void Continue()
    {
        if (_navMeshAgent.isOnNavMesh)
            _navMeshAgent.isStopped = false;
    }

    public void WarpAgent()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, _warpDistance, NavMesh.AllAreas))
        {
            _navMeshAgent.Warp(hit.position);
        }
    }
}


