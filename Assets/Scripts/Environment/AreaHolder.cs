using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CollisionInteractable))]
public class AreaHolder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [Range(1, 10)] float _insideTime;

    public UnityEvent successEvent;

    CollisionInteractable _collisionInteractable => GetComponent<CollisionInteractable>();

    float _elapsedTime;
    bool _playerInside;

    private void Awake()
    {
        _collisionInteractable.enterEvent.AddListener(PlayerEntered);
        _collisionInteractable.exitEvent.AddListener(PlayerExited);
    }

    private void Update()
    {
        if (_playerInside)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _insideTime)
            {
                successEvent.Invoke();

                _playerInside = false;
            }
        }
    }

    void PlayerEntered()
    {
        _elapsedTime = 0;
        _playerInside = true;
    }

    void PlayerExited()
    {
        _playerInside = false;
    }


}
