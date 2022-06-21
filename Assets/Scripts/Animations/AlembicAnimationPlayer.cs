using System;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;


[System.Serializable]
public struct AlembicAnimation
{
    [SerializeField] public string animationName;
    [SerializeField] public float startTime;
    [SerializeField] public float endTime;
    [SerializeField] public bool loop;
    [SerializeField] public string nextAnimationName;
}


public class AlembicAnimationPlayer : MonoBehaviour
{
    private AlembicStreamPlayer _aspl => GetComponent<AlembicStreamPlayer>();

    [Header("Animations")] [SerializeField]
    private AlembicAnimation[] alembicAnimations;

    [SerializeField] private AlembicAnimation _currentAnimation;


    private void Awake()
    {
        PlayAnimation(alembicAnimations[1].animationName);
    }

    private void Update()
    {
        if (_aspl.CurrentTime >= _currentAnimation.endTime) return;

        _aspl.CurrentTime += Time.deltaTime;
        if (_aspl.CurrentTime >= _currentAnimation.endTime && _currentAnimation.loop)
        {
            _aspl.CurrentTime = _currentAnimation.startTime;
        }
        if (!_currentAnimation.loop && _aspl.CurrentTime >= _currentAnimation.endTime)
        {
            PlayAnimation(_currentAnimation.nextAnimationName);
        }
    }

    public void PlayAnimation(string name)
    {
        AlembicAnimation a = Array.Find(alembicAnimations, alembicAnimation => alembicAnimation.animationName == name);
        if (a.animationName == null)
        {
            Debug.LogWarning("Animation: " + name + " not found!");
            return;
        }
        _currentAnimation = a;
        _aspl.CurrentTime = a.startTime;
    }

    public bool HasAnimationEnded()
    {
        if (!_currentAnimation.loop)
            return _aspl.CurrentTime >= _currentAnimation.endTime;
        return false;
    }

    [ContextMenu("PlayWalk")]
    public void PlayWalk()
    {
        PlayAnimation("Walk");
    }

    [ContextMenu("PlayAccelerate")]
    public void PlayAccelerate()
    {
        PlayAnimation("Accelerate");
    }
}