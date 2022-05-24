using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound : MonoBehaviour
{
    public AudioClip clip;
    public string soundName;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
    public bool loop; 
    public bool sfx;

    [HideInInspector]
    public AudioSource audioSource;

    [HideInInspector]
    public float time;
}
