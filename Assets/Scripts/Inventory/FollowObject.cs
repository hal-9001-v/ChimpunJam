using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _target;

    [Header("Settings")]
    [SerializeField] [Range(0.1f, 10)] float _speed;
    [SerializeField] [Range(0.1f, 10)] float _minDistance;

    float _minMagnitudeDistance;

    private void Awake()
    {
        _minMagnitudeDistance = _minDistance * _minDistance;
    }

    private void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if (_target)
        {
            Vector3 direction = _target.position - transform.position;
            if (direction.magnitude > _minMagnitudeDistance + 0.1f)
            {
                transform.position += direction.normalized * _speed * Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _minDistance);
    }
}
