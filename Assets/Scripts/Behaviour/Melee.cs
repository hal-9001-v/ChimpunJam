using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class Melee : MonoBehaviour
{
    // Cuando colidee cosa de melee con cosa de health se llama a hurt()
    [Header("Hit Values")]
    [SerializeField][Range(0,10)] private float _damage;
    [SerializeField][Range(0,10)] private float _push;
    public Action hitAction;
    
    private void OnTriggerEnter(Collider other) {
        Hit(transform, other, transform.position);
    }

    private void Hit(Transform source, Collider coll, Vector3 pos)
    {
        var health = coll.GetComponent<Health>();
        if (coll.isTrigger == true && health)
        {
            //Debug.Log("HURT");
            health.Hurt(_damage, pos, _push, source);

            if (hitAction != null)
                hitAction.Invoke();

        }
    }
}