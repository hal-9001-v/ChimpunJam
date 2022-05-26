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

    bool _preparing;

    private void Awake()
    {
        _areaHolder.successEvent.AddListener(PrepareEgg);
    }

    void PrepareEgg()
    {
        if (_preparing == false)
        {
            _preparing = true;
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(_preparationTime);

        _effectProvider.RestoreItem();
        _preparing = false;
    }
}
