using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Exploder))]
public class ExplosionEffect : ItemEffect
{
    Exploder _exploder => GetComponent<Exploder>();


    public override void ApplyEffect()
    {
        _exploder.Explode();
    }


}
