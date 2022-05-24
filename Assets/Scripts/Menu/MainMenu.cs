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

    private void Awake()
    {
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
           DisplaySettings();
       });
        tutorialButton.onClick.AddListener(() =>
       {
           DisplayTutorial();
       });
        quit.onClick.AddListener(() =>
       {
           Application.Quit();
       });
    }

    private void Play()
    {
        LevelLoader.Instance.LoadLevel(1);
    }

    private void DisplaySettings()
    {
        SettingsManager.Instance.DisplaySettings();
    }

    private void DisplayTutorial()
    {

    }

}
