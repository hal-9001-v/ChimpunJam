using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrototypeProvider : MonoBehaviour
{
    [Header("Prototypes")]
    [SerializeField] TrainEffect _trainPrototype;


    public TrainEffect CloneTrainEffect()
    {
        var clone = Instantiate(_trainPrototype);

        return clone;
    }

}
