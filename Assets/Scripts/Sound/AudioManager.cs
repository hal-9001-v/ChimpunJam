using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] AudioMixerGroup music;
    [SerializeField] AudioMixerGroup sfx;
    public Sound[] sounds;

        private void Awake()
    {
        //Singleton AudioManager
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else Destroy(this.gameObject);

        //create audiosource for each sound s and assign variables
        foreach (Sound s in sounds)
        {

            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;

            //Add to mixer group 
            if(s.sfx) s.audioSource.outputAudioMixerGroup = sfx;
            else s.audioSource.outputAudioMixerGroup = music;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (s.audioSource != null) s.audioSource.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.time = s.audioSource.time;
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.audioSource.Pause();
    }

    public void Resume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
                {
                    Debug.LogWarning("Sound: " + name + " not found!");
                    return;
        }       
         s.audioSource.Play();
        if (s.time != 0 || s.time != -1) s.audioSource.time = s.time;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }       
         s.audioSource.Stop();
    }
    public void StopMusic(){
        foreach(Sound s in sounds){
            if(!s.sfx) s.audioSource.Stop();
        }
    }

    public void StopEverything(){
          foreach(Sound s in sounds){
            s.audioSource.Stop();
        }
    }

}
