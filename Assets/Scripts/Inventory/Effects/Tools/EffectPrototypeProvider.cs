using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrototypeProvider : MonoBehaviour
{
    [Header("Prototypes")]
    [SerializeField] InventoryItem _trainPrototype;
    [SerializeField] InventoryItem _gnomePrototype;
    [SerializeField] InventoryItem _babyDuckPrototype;
    [SerializeField] InventoryItem _humanBabyPrototype;
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

    public InventoryItem CloneHumanBabyPrototype()
    {
        var clone = Instantiate(_humanBabyPrototype);

        return clone;
    }

    public InventoryItem CloneFrenchRobot()
    {
        var clone = Instantiate(_frenchPrototype);

        return clone;
    }


    public InventoryItem GetRandomItem()
    {
        InventoryItem clone = null;
        switch (Random.Range(0, 5))
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
                clone = CloneHumanBabyPrototype();
                break;
            case 4:
                clone = CloneFrenchRobot();
                break;
            default:

                break;
        }

        return clone;
    }

}
