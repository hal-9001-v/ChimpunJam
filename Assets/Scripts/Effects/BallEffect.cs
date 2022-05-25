using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffect : ItemEffect
{
    [Header("References")]
    [SerializeField] InertiaHurter _inertiaHurter;
    [SerializeField] Rigidbody _ball;

    [Header("Settings")]
    [SerializeField] [Range(1, 10)] float _duration;

    private void Awake()
    {
        ResetBall();
    }

    public override void ApplyEffect()
    {
        FreeBall();

        StartCoroutine(CountDown());

    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(_duration);
        ResetBall();
    }

    void ResetBall()
    {
        _inertiaHurter.transform.parent = transform;
        _inertiaHurter.transform.position = transform.position;

        _inertiaHurter.EnableBall(false);
    }

    void FreeBall()
    {
        _inertiaHurter.transform.parent = null;
        _inertiaHurter.EnableBall(true);

    }
}
