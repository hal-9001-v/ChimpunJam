using System;
using UnityEngine;
using UnityEngine.VFX;

public class VFXPlayer : MonoBehaviour
{
    private VisualEffect _vfx => GetComponent<VisualEffect>();

    private bool _enabled;

    private void Update()
    {
        if (_enabled)
        {
            Destroy(gameObject, 3.5f);
        }
    }

    public void EnableVFX()
    {
        _vfx.Play();
        _enabled = true;
    }

    public void StopVFX()
    {
        _vfx.Stop();
        _enabled = false;
    }
}
