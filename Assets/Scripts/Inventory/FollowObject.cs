using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _target;

    [Header("Settings")]
    [SerializeField] [Range(0.1f, 10)] float _speed;

    float _minMagnitudeDistance;

    private void Awake()
    {
        if (_target)
        {
            _minMagnitudeDistance = Vector3.Magnitude(_target.position - transform.position);
            _minMagnitudeDistance *= _minMagnitudeDistance;
        }
    }

    private void FixedUpdate()
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
                transform.position += direction.normalized * _speed * Time.fixedDeltaTime;
            }
        }
    }
}
