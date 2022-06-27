using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HitMarker : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [Range(0.1f, 1)] float _scaleDuration;
    [SerializeField] LayerMask _layerMask;

    Image _image => GetComponent<Image>();

    Camera _camera => FindObjectOfType<Camera>();

    Vector3 _originalScale;

    Coroutine _showCoroutine;

    private void Awake()
    {
        _image.enabled = false;

        _originalScale = transform.localScale;
    }

    public void Hit(Transform sword, Collider hitCollider)
    {
        RaycastHit hit;
        Ray ray = new Ray(sword.position, hitCollider.transform.position - sword.position);

        if (Physics.Raycast(ray, out hit, 10, _layerMask))
        {
            _image.transform.position = _camera.WorldToScreenPoint(hit.point);

            StopAllCoroutines();
            StartCoroutine(Show());
        }
    }

    IEnumerator Show()
    {
        _image.enabled = true;

        float elapsedTime = 0;

        while (elapsedTime < _scaleDuration)
        {
            elapsedTime += Time.deltaTime;

            transform.localScale = _originalScale * elapsedTime / _scaleDuration;

            yield return null;
        }

        transform.localScale = _originalScale;

        yield return new WaitForSeconds(0.1f);

        _image.enabled = false;
    }

}
