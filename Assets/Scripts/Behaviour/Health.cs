using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] HealthTag _healthTag;
    public HealthTag healthTag { get { return _healthTag; } }

    [Header("Values")]
    [SerializeField] [Range(0, 10)] float _maxHealth;

    public bool canGetHurt = true;
    public float currentHealth;

    public Action<Vector3, float, Transform> hurtAction;
    public Action<Vector3, float, Transform> deadAction;

    public bool isAlive
    {
        get
        {
            return currentHealth <= 0;
        }
        private set
        {

        }
    }

    private void Awake()
    {
        currentHealth = _maxHealth;

    }

    public void Hurt(float dmg, Vector3 source, float push, Transform hitter)
    {
        if (canGetHurt)
        {
            //Debug.Log("HIT");
            currentHealth -= Mathf.Abs(dmg);

            if (currentHealth > 0)
            {
                if (hurtAction != null)
                    hurtAction.Invoke(source, push, hitter);

            }
            else
            {
                //Make sure it doesn't get a below zero value just in case
                currentHealth = 0;

                if (deadAction != null)
                    deadAction.Invoke(source, push, hitter);

            }
        }

    }

    [ContextMenu("Matar")]
    public void Kill()
    {
        Hurt(float.MaxValue, transform.position, 1000f, transform);
    }



}
