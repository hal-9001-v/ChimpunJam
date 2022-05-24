using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    [Header("Button References")]
    [SerializeField] Button playButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button tutorialButton;
    [SerializeField] Button quit;

    private LevelLoader _levelLoader;
    private AudioManager _audioManager;
    private void Awake()
    {
        _levelLoader = FindObjectOfType<LevelLoader>();
        _audioManager = FindObjectOfType<AudioManager>();
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        playButton.onClick.AddListener(() =>
        {
            Play();
        });
        settingsButton.onClick.AddListener(() =>
       {

       });
        tutorialButton.onClick.AddListener(() =>
       {

       });
        quit.onClick.AddListener(() =>
       {
           Application.Quit();
       });
    }

    private void Play()
    {
        _levelLoader.LoadLevel(1);
    }

    private void DisplaySettings()
    {

    }

    private void DisplayTutorial()
    {

    }

}
