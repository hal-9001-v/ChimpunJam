using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Renderer[] _renderers;
    [SerializeField] Collider[] _colliders;


    public bool hideRenderers = true;
    public bool hideColliders;


    private void Awake()
    {
        if (hideRenderers)
        {
            if (_renderers == null || _renderers.Length == 0)
            {
                _renderers = GetComponentsInChildren<Renderer>();
            }
        }

        if (hideColliders)
        {
            if (_colliders == null || _colliders.Length == 0)
            {
                _colliders = GetComponentsInChildren<Collider>();
            }
        }
    }

    public void Show(bool value)
    {
        if (hideRenderers)
        {
            if (_renderers != null && _renderers.Length != 0)
            {
                foreach (var renderer in _renderers)
                {
                    renderer.enabled = value;
                }
            }
        }

        if (hideColliders)
        {
            if (_colliders != null && _colliders.Length != 0)
            {
                foreach (var collider in _colliders)
                {
                    collider.enabled = value;
                }
            }
        }
    }

}
