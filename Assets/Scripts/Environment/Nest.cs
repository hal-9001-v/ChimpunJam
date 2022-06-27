using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaHolder))]
public class Nest : MonoBehaviour
{

    [Header("References")]
    [SerializeField] CollisionItemAdder _effectProvider;
    [SerializeField] Transform _egg;
    [SerializeField] Clock _clock;

    [Header("Settings")]
    [SerializeField] [Range(1, 30)] float _preparationTime;
    [SerializeField] [Range(0.1f, 2)] float _growTime;
    AreaHolder _areaHolder => GetComponent<AreaHolder>();

    Vector3 _originalSize;

    bool _preparing;

    public int eggsAvaliable = 0;
    
    private void Awake()
    {
        _originalSize = _egg.localScale;
        _areaHolder.successEvent.AddListener(PrepareEgg);

        _egg.localScale = Vector3.zero;
    }



    void PrepareEgg()
    {
        if (_preparing == false && eggsAvaliable > 0)
        {
            eggsAvaliable--;

            _preparing = true;
            StartCoroutine(GrowEgg());
            StartCoroutine(CountDown());

            _clock.StartCount(_preparationTime);
        }
    }

    IEnumerator GrowEgg()
    {
        float elapsedTime = 0;

        while (elapsedTime < _growTime)
        {
            elapsedTime += Time.deltaTime;

            _egg.transform.localScale = Vector3.Lerp(Vector3.zero, _originalSize, elapsedTime / _growTime);

            yield return null;
        }

        _egg.transform.localScale = _originalSize;
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(_preparationTime);

        _effectProvider.RestoreItem();
        _preparing = false;

        _egg.transform.localScale = Vector3.zero;

    }


}
