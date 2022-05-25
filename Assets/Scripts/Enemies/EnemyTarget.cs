using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyTarget : MonoBehaviour
{
    public Health targetHealth { get; private set; }

    private void Awake()
    {
        targetHealth = GetComponent<Health>();
    }



}
