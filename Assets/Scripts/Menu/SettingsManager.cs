using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;
public class SettingsManager : MonoBehaviour
{

    [Header("References")]
    [SerializeField] AudioMixer _audioMixer;

    [Header("Sliders")]

    [SerializeField] private Slider _SFX;
    [SerializeField] private Slider _master;
    [SerializeField] private Slider _music;

    [Header("Buttons")]
    [SerializeField] private Button _menu;

    const string MasterAudioKey = "Master";
    const string MusicAudioKey = "Music";
    const string SFXAudioKey = "SFX";
    const float MaxAudioValue = 1f;
    const float MinAudioValue = 0.001f;

    public static SettingsManager instance;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else Destroy(this.gameObject);
        SetSliders();

        /*_englishButton.onClick.AddListener(() =>
        {
            SetLanguage(Language.English);
        });
        _spanishButton.onClick.AddListener(() =>
        {
            SetLanguage(Language.Spanish);
        });*/
    }

    private void SetSliders(){
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
         value = Mathf.Pow(10,value/20);
        slider.value = value;
    }
      public void SetMasterVolume(float newVolume)
    {
        _audioMixer.SetFloat(MasterAudioKey, Mathf.Log10(newVolume)*20);
    }

    public void SetMusicVolume(float newVolume)
    {
        _audioMixer.SetFloat(MusicAudioKey, Mathf.Log10(newVolume)*20);
    }

    public void SetSFXVolume(float newVolume)
    {
        _audioMixer.SetFloat(SFXAudioKey, Mathf.Log10(newVolume)*20);
    }

}
