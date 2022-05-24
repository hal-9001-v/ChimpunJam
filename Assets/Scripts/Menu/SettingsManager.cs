using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;
public class SettingsManager : MonoBehaviour
{

    [Header("References")]
    [SerializeField] AudioMixer _audioMixer;
    private Animator _settingsAnimator;

    [Header("Sliders")]

    [SerializeField] private Slider _SFX;
    [SerializeField] private Slider _master;
    [SerializeField] private Slider _music;

    [Header("Buttons")]
    [SerializeField] private Button _menu;
    [SerializeField] private Button _englishButton;
    [SerializeField] private Button _spanishButton;
    const string MasterAudioKey = "Master";
    const string MusicAudioKey = "Music";
    const string SFXAudioKey = "SFX";
    const string LoadTrigger = "Start";
    const string EndLoadTrigger = "End";
    const float MaxAudioValue = 1f;
    const float MinAudioValue = 0.001f;

    public static SettingsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else Destroy(this.gameObject);

        _settingsAnimator = GetComponentInChildren<Animator>();
        SetSliders();
        SetButtons();

        _englishButton.onClick.AddListener(() =>
        {
            SetLanguage(Language.English);
        });
        _spanishButton.onClick.AddListener(() =>
        {
            SetLanguage(Language.Spanish);
        });
    }

    private void SetButtons()
    {
        _menu.onClick.AddListener(() =>
          {
              ReturnToMenu();
          });
    }

    private void SetSliders()
    {
        SetSlider(_master, SetMasterVolume, MasterAudioKey);
        SetSlider(_music, SetMusicVolume, MusicAudioKey);
        SetSlider(_SFX, SetSFXVolume, SFXAudioKey);
    }

    void SetSlider(Slider slider, UnityAction<float> onValueChanged, string groupKey)
    {
        slider.onValueChanged.AddListener(onValueChanged);

        slider.minValue = MinAudioValue;
        slider.maxValue = MaxAudioValue;
        float value;
        _audioMixer.GetFloat(groupKey, out value);
        value = Mathf.Pow(10, value / 20);
        slider.value = value;
    }
    public void SetMasterVolume(float newVolume)
    {
        _audioMixer.SetFloat(MasterAudioKey, Mathf.Log10(newVolume) * 20);
    }

    public void SetMusicVolume(float newVolume)
    {
        _audioMixer.SetFloat(MusicAudioKey, Mathf.Log10(newVolume) * 20);
    }

    public void SetSFXVolume(float newVolume)
    {
        _audioMixer.SetFloat(SFXAudioKey, Mathf.Log10(newVolume) * 20);
    }

    public void DisplaySettings()
    {
        StartCoroutine(DisplaySettingsC());
    }

    public void ReturnToMenu()
    {
        StartCoroutine(ReturnToMenuC());
    }
    public IEnumerator ReturnToMenuC()
    {
        _settingsAnimator.SetTrigger(EndLoadTrigger);
        yield return new WaitForSeconds(2f);
        _settingsAnimator.ResetTrigger(EndLoadTrigger);
    }

    private IEnumerator DisplaySettingsC()
    {
        _settingsAnimator.SetTrigger(LoadTrigger);
        yield return new WaitForSeconds(2f);
        _settingsAnimator.ResetTrigger(LoadTrigger);
    }

    private void SetLanguage(Language language){
                switch (language)
        {
            case Language.English:
                Debug.Log("English!");
                LanguageContext.Instance.ChangeLanguage(Language.English);
                break;
            case Language.Spanish:
                Debug.Log("Spanish!");
                LanguageContext.Instance.ChangeLanguage(Language.Spanish);
                break;
        }
    }

}   
