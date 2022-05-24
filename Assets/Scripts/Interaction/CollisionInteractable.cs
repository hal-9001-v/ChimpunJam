using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class CollisionInteractable : MonoBehaviour
{
    [Header("Settings")]

    [SerializeField] bool _enterOnlyOnce;
    [SerializeField] bool _exitOnlyOnce;

    public UnityEvent enterEvent;
    public UnityEvent exitEvent;


    bool _enterDone;
    bool _exitDone;

    public void EnterInteraction()
    {
        if (_enterOnlyOnce && _enterDone)
            return;

        _enterDone = true;

        enterEvent.Invoke();

    }

    public void ExitInteraction()
    {
        if (_exitOnlyOnce && _exitDone)
            return;

        _exitDone = true;

        exitEvent.Invoke();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractionTrigger>() != null)
        {
            EnterInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractionTrigger>() != null)
        {
            ExitInteraction();
        }
    }


}
