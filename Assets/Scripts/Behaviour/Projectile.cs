using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Projectile : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] UnityEvent _onHitHealth;
    [SerializeField] UnityEvent _onHit;
    [SerializeField] HealthTag _targetTag;

    //References
    Rigidbody _rigidBody;
    Collider[] _colliders;
    Renderer[] _renderers;

    float _damage = 1;
    float _push = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        _rigidBody = GetComponent<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();

        _renderers = GetComponentsInChildren<Renderer>();


        //Nullify parent so it doesn't move with hierarchy on any way.
        transform.parent = null;

        Hide();
    }

    private void Update()
    {
        transform.forward = _rigidBody.velocity.normalized;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null && health.healthTag == _targetTag)
        {
            health.Hurt(_damage, transform.position, _push, transform);

            _onHitHealth.Invoke();
        }

        _onHit.Invoke();
        Hide();

    }

    public void Launch(Vector3 startingPosition, Vector3 velocity, float damage, float push)
    {
        Show();

        _damage = damage;
        _push = push;

        transform.position = startingPosition;
        _rigidBody.velocity = velocity;

    }

    public void Launch(Vector3 startingPosition, float velocity, float damage, float push, Transform target)
    {
        Launch(startingPosition, (target.position - startingPosition).normalized * velocity, damage, push);
    }

    public void Show()
    {
        _rigidBody.isKinematic = false;
        foreach (var collider in _colliders)
        {
            collider.enabled = true;
        }

        foreach (var renderer in _renderers)
        {
            renderer.enabled = true;
        }
    }
    public void Hide()
    {
        _rigidBody.isKinematic = true;
        _rigidBody.velocity = Vector3.zero;

        foreach (var collider in _colliders)
        {
            collider.enabled = false;
        }

        foreach (var renderer in _renderers)
        {
            renderer.enabled = false;
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
