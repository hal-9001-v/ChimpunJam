using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class InertiaHurter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] HealthTag _targetTag;

    [SerializeField] [Range(1, 10)] int _damage;
    [SerializeField] [Range(1, 20)] float _minimumSpeedForDamage;
    [SerializeField] [Range(1, 20)] float _thrust;

    Hurter _hurter => GetComponent<Hurter>();
    Rigidbody _rigidbody => GetComponent<Rigidbody>();

    Collider _collider => GetComponent<Collider>();


    public void EnableBall(bool value)
    {
        _collider.enabled = value;

        if (value)
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.collider.gameObject.GetComponent<Health>();
        if (health)
        {
            if (_targetTag == health.healthTag)
            {
                health.Hurt(_damage, transform.position, _thrust, transform);
            }
            else
            {
                var direction = transform.position - health.transform.position;
                direction.y = 0;

                _rigidbody.AddForce(direction.normalized * _thrust, ForceMode.VelocityChange);

            }
        }
    }


}
