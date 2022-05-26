using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaHolder))]
public class Nest : MonoBehaviour
{

    [Header("References")]
    [SerializeField] CollisionItemAdder _effectProvider;

    [Header("Settings")]
    [SerializeField] [Range(1, 30)] float _preparationTime;
    AreaHolder _areaHolder => GetComponent<AreaHolder>();


    private void Awake()
    {
        _areaHolder.successEvent.AddListener(PrepareEgg);
    }

    void PrepareEgg()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(_preparationTime);

        _effectProvider.RestoreItem();
    }
}
