using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HitSpinner : MonoBehaviour
{
    Health _health => GetComponent<Health>();

    // Start is called before the first frame update
    void Start()
    {
        _health.hurtAction += (pos, push, hitter) =>
        {

            transform.eulerAngles += Vector3.up * 5;
        };

        _health.currentHealth = float.MaxValue;
    }

}
