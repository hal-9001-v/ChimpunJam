using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrototypeProvider : MonoBehaviour
{
    [Header("Prototypes")]
    [SerializeField] InventoryItem _trainPrototype;
    [SerializeField] InventoryItem _gnomePrototype;
    [SerializeField] InventoryItem _babyDuckPrototype;


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

    public InventoryItem GetRandomItem()
    {
        InventoryItem clone = null;
        switch (Random.Range(0, 3))
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

            default:

                break;
        }

        return clone;
    }

}
