using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] AnimationCurve _rotationHeight;
    [SerializeField] [Range(0.1f, 5)] float _lerpSpeed;

    ItemEffect _effect => GetComponent<ItemEffect>();

    public ItemEffect effect { get { return _effect; } }

    Transform _followParent;

    bool _lerping;
    bool _useHeightCurve;

    Vector3 _lerpStart;
    float _lerpTargetTime;
    float _lerpElapsedTime;

    public bool isNeeded;

    public void UseItem()
    {
        if (_effect)
        {
            _effect.ApplyEffect();
        }
    }

    public void SetParent(Transform parent, bool useHeightCurve)
    {
        _followParent = parent;
        _lerpStart = transform.position;
        _lerpTargetTime = Vector3.Distance(_lerpStart, _followParent.transform.position) / _lerpSpeed;
        _lerpElapsedTime = 0;

        _lerping = true;
        _useHeightCurve = useHeightCurve;
    }

    private void Update()
    {
        if (_lerping)
        {
            _lerpElapsedTime += Time.deltaTime;


            if (_lerpElapsedTime >= _lerpTargetTime)
            {
                _lerping = false;

                transform.parent = _followParent;
                transform.position = _followParent.position;
            }
            else
            {
                transform.position = Vector3.Lerp(_lerpStart, _followParent.position, _lerpElapsedTime / _lerpTargetTime);

                if (_useHeightCurve)
                {
                    transform.position += _rotationHeight.Evaluate(_lerpElapsedTime / _lerpTargetTime) * Vector3.up;
                }

            }
        }
    }

}
