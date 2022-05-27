using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [Range(0.1f, 1)] float _minDistance;
    [SerializeField] [Range(0.1f, 1)] float _takeTime;

    public bool isMoving { get; private set; }
    public Vector3 movementDirection { get; private set; }

    public Action movingAction;
    public Action stopAction;

    float _elapsedTime;
    Vector3 _previousPosition;

    private void Update()
    {
        if (_elapsedTime > _takeTime)
        {
            movementDirection = transform.position - _previousPosition;
            if (movementDirection.sqrMagnitude > _minDistance * _minDistance)
            {
                isMoving = true;

                if (movingAction != null)
                {
                    movingAction.Invoke();
                }
            }
            else
            {
                isMoving = false;

                if (stopAction != null)
                {
                    stopAction.Invoke();
                }
            }

            movementDirection.Normalize();
            _previousPosition = transform.position;
            _elapsedTime = 0;
        }
        else
        {
            _elapsedTime += Time.deltaTime;
        }


    }
}
