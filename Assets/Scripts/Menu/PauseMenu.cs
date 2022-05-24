using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Button References")]
    [SerializeField] Button resumeButton;
    [SerializeField] Button returnToMenuBtton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button quit;

    private Animator _pauseAnimator;
    const string LoadTrigger = "Start";
    const string EndLoadTrigger = "End";
    private void Awake()
    {
        _pauseAnimator = GetComponentInChildren<Animator>();
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        resumeButton.onClick.AddListener(() =>
        {
            HidePauseMenu();
        });
        settingsButton.onClick.AddListener(() =>
       {
           DisplaySettings();
       });
        returnToMenuBtton.onClick.AddListener(() =>
       {
           ReturnToMenu();
       });
        quit.onClick.AddListener(() =>
       {
           Application.Quit();
       });
    }

    public void DisplayPauseMenu()
    {
        Time.timeScale = 0f;
        StartCoroutine(DisplayPauseC());
    }
    private void HidePauseMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(HidePauseC());
    }
    private void ReturnToMenu()
    {
        Time.timeScale = 1f;
        LevelLoader.Instance.LoadLevel(0);
    }
    private void DisplaySettings()
    {
        SettingsManager.Instance.DisplaySettings();
    }

    private IEnumerator DisplayPauseC()
    {
        _pauseAnimator.SetTrigger(LoadTrigger);
        yield return new WaitForSeconds(2f);
        _pauseAnimator.ResetTrigger(LoadTrigger);
    }
    private IEnumerator HidePauseC()
    {
        _pauseAnimator.SetTrigger(EndLoadTrigger);
        yield return new WaitForSeconds(2f);
        _pauseAnimator.ResetTrigger(EndLoadTrigger);
    }

}
