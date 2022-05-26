using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using System.Collections;
using System.Collections.Generic;

public class SwordController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _ikTarget;
    [SerializeField] Rig _ikRig;

    [SerializeField] Hurter _hurter;
    [SerializeField] TrailRenderer _trailRenderer;


    [Header("Settings")]
    [SerializeField] [Range(100, 1000)] float _range = 200;
    [SerializeField] [Range(0.1f, 1)] float _lerpFactor = 0.5f;
    [SerializeField] [Range(0.1f, 1)] float _transitionTime = 0.5f;

    public Queue<CombinedEffects> effects = new();
    Camera _camera => FindObjectOfType<Camera>();

    bool _usingSword = false;

    Vector3 _targetStartingPosition;

    Coroutine _modifyCoroutine;

    private void Awake()
    {
        _targetStartingPosition = _ikTarget.localPosition;

        _hurter.hitAction += UseEffect;

        EnableSword(false);
    }

    public void EnableSword(bool value)
    {
        _usingSword = value;
        _hurter.EnableAttackColliders(value);
        _trailRenderer.enabled = value;

        if (_usingSword)
        {
            _ikTarget.localPosition = _targetStartingPosition;

            ModifyIKWeight(1, _transitionTime);
        }
        else
        {
            ModifyIKWeight(0, _transitionTime);
        }

    }

    private void Update()
    {
        SwingSword();
    }

    void ModifyIKWeight(float targetValue, float time)
    {
        if (_modifyCoroutine != null)
        {
            StopCoroutine(_modifyCoroutine);
        }

        _modifyCoroutine = StartCoroutine(ModifyIKWeightCoroutine(targetValue, time));
    }

    IEnumerator ModifyIKWeightCoroutine(float targetValue, float time)
    {
        float elapsedTime = 0;
        float startingValue = _ikRig.weight;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;

            _ikRig.weight = startingValue * (1 - elapsedTime / time) + targetValue * (elapsedTime / time);

            yield return null;
        }

        _ikRig.weight = targetValue;

    }

    void SwingSword()
    {
        if (_usingSword)
        {
            var ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _range))
            {
                _ikTarget.transform.position = Vector3.Lerp(_ikTarget.transform.position, hit.point, _lerpFactor);
            }
        }
    }

    public void AddEffects(ItemEffect[] itemEffects)
    {
        if (itemEffects.Length != 4)
        {
            Debug.LogWarning("Must be 4! Provided are " + itemEffects.Length);
            return;
        }

        effects.Enqueue(new CombinedEffects(itemEffects));
    }

    public void UseEffect()
    {
        var usedEffect = effects.Dequeue();
        foreach (var effect in usedEffect.itemEffects)
        {
            effect.ApplyEffect();
        }

        effects.Enqueue(usedEffect);
    }

    public class CombinedEffects
    {
        public ItemEffect[] itemEffects { get; private set; }

        public CombinedEffects(ItemEffect[] effects)
        {
            itemEffects = effects;
        }
    }

}
