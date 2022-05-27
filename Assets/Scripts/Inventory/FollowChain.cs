using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChain : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform[] _slots;

    public Transform[] slots { get { return _slots; } }

    [Header("Settings")]
    [SerializeField] [Range(0.01f, 1)] float _lerpFactor;
    [SerializeField] [Range(0.1f, 10)] float _minDistance;

    [SerializeField] bool _lockXRotation;
    [SerializeField] bool _lockYRotation;
    [SerializeField] bool _lockZRotation;

    Rigidbody _rigidbody => GetComponent<Rigidbody>();



    float _minMagnitudeDistance;

    public bool stopFollowing;

    private void Awake()
    {
        _minMagnitudeDistance = _minDistance * _minDistance;
    }

    private void Update()
    {
        UpdatePositions();
    }

    void UpdatePositions()
    {
        if (stopFollowing) return;

        for (int i = 1; i < _slots.Length; i++)
        {
            var direction = _slots[i - 1].position - _slots[i].position;

            if (direction.magnitude > _minDistance)
            {
                _slots[i].position = Vector3.Lerp(_slots[i].position, _slots[i - 1].position, _lerpFactor);

                if (_lockXRotation)
                    direction.x = 0;
                if (_lockYRotation)
                    direction.y = 0;
                if (_lockZRotation)
                    direction.z = 0;

                direction.Normalize();
                _slots[i].forward = Vector3.Lerp(_slots[i].forward, direction, _lerpFactor);
            }
        }

    }

    private void OnDrawGizmos()
    {
        foreach (var slot in _slots)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(slot.position, _minDistance);
        }
    }
}
