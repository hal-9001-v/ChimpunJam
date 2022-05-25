using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrototypeProvider : MonoBehaviour
{
    [Header("Prototypes")]
    [SerializeField] InventoryItem _trainPrototype;
    [SerializeField] InventoryItem _gnomePrototype;
    [SerializeField] InventoryItem _babyDuckPrototype;
    [SerializeField] InventoryItem _explosionPrototype;
    [SerializeField] InventoryItem _ballPrototype;
    [SerializeField] InventoryItem _frenchPrototype;


    public InventoryItem CloneTrainItem()
    {
        var clone = Instantiate(_trainPrototype);

        return clone;
    }

    public InventoryItem CloneGnomeItem()
    {
        var clone = Instantiate(_gnomePrototype);

        return clone;
    }

    public InventoryItem CloneBabyDuckItem()
    {
        var clone = Instantiate(_babyDuckPrototype);

        return clone;
    }

    public InventoryItem CloneExplosionPrototype()
    {
        var clone = Instantiate(_explosionPrototype);

        return clone;
    }

    public InventoryItem CloneFrenchRobot()
    {
        var clone = Instantiate(_frenchPrototype);

        return clone;
    }

    public InventoryItem CloneBallItem()
    {
        var clone = Instantiate(_ballPrototype);

        return clone;
    }


    public InventoryItem GetRandomItem()
    {
        InventoryItem clone = null;
        switch (Random.Range(0, 6))
        {
            case 0:
                clone = CloneTrainItem();
                break;
            case 1:
                clone = CloneGnomeItem();
                break;

            case 2:
                clone = CloneBabyDuckItem();
                break;
            case 3:
                clone = CloneExplosionPrototype();
                break;
            case 4:
                clone = CloneFrenchRobot();
                break;

            case 5:
                clone = CloneBallItem();
                break;
            default:

                break;
        }

        return clone;
    }

}
