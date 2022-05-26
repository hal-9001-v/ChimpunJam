using UnityEngine;
using UnityEngine.VFX;

public class VFXPlayer : MonoBehaviour
{
    private VisualEffect _vfx => GetComponent<VisualEffect>();

    private bool _enabled;
    private void Update()
    {
        if (_vfx.aliveParticleCount == 0 && _enabled)
        {
            Destroy(gameObject);
        }
    }

    public void EnableVFX()
    {
        _enabled = true;
        _vfx.Play();
    }

    public void StopVFX()
    {
        _enabled = false;
        _vfx.Stop();
    }
}
