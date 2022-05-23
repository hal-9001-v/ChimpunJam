using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] AnimationCurve _rotationHeight;
    [SerializeField] [Range(0.1f, 5)] float _lerpSpeed;

    FollowObject _follow;

    bool _lerping;
    bool _useHeightCurve;

    Vector3 _lerpStart;
    float _lerpTargetTime;
    float _lerpElapsedTime;


    public void SetFollower(FollowObject follow, bool useHeightCurve)
    {
        if (follow)
        {
            _follow = follow;

            _lerpStart = transform.position;
            _lerpTargetTime = Vector3.Distance(_lerpStart, follow.transform.position) / _lerpSpeed;
            _lerpElapsedTime = 0;

            _lerping = true;
            _useHeightCurve = useHeightCurve;

        }
    }

    private void Update()
    {
        if (_lerping)
        {
            _lerpElapsedTime += Time.deltaTime;


            if (_lerpElapsedTime >= _lerpTargetTime)
            {
                _lerping = false;


                transform.parent = _follow.transform;
                transform.position = _follow.transform.position;
            }
            else
            {
                transform.position = Vector3.Lerp(_lerpStart, _follow.transform.position, _lerpElapsedTime / _lerpTargetTime);

                if (_useHeightCurve)
                {
                    transform.position += _rotationHeight.Evaluate(_lerpElapsedTime / _lerpTargetTime) * Vector3.up;
                }

            }
        }
    }

}
