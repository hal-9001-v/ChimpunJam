using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceInteractable : Interactable
{
    bool _done;
    [SerializeField] bool _onlyOnce;

    [SerializeField] UnityEvent _distanceEvent;

    [SerializeField] [Range(0, 20)] float _distance;

    Transform _target;

    private void Start()
    {
        var trigger = FindObjectOfType<InteractionTrigger>();
        
        if (trigger != null)
        {
            _target = trigger.transform;
        }
    }

    public override void Interaction()
    {
        if (_onlyOnce && _done)
            return;

        _done = true;

        _distanceEvent.Invoke();

    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.position) < _distance)
            {
                Interaction();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _distance);
    }




}
