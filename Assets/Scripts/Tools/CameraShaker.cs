using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShaker : MonoBehaviour
{
    public static CameraShaker Instance { get; private set; }
    private CinemachineVirtualCamera _cVc;

    private float _timer;
    private float _timerTotal;

    private float _restoreTimer;
    private float _restoreTimerTotal;

    private float _deafultFrecuency;
    private float _deafultAmplitude;
    private float _startingAmplitude;
    private float _startingFrequency;

    private NoiseSettings _handCamNoiseProfile;

    [Header("References")]
    [SerializeField] NoiseSettings shakeNoiseProfile;

    private void Awake()
    {
        Instance = this;
        _cVc = GetComponent<CinemachineVirtualCamera>();
        CinemachineBasicMultiChannelPerlin cbcp = _cVc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _deafultAmplitude = cbcp.m_AmplitudeGain;
        _deafultFrecuency = cbcp.m_FrequencyGain;
        _handCamNoiseProfile = cbcp.m_NoiseProfile;


    }

    public void ShakeCam(float amplitude, float frequency, float time)
    {

        CinemachineBasicMultiChannelPerlin cbcp = _cVc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cbcp.m_NoiseProfile = shakeNoiseProfile;
        cbcp.m_AmplitudeGain = amplitude;
        cbcp.m_FrequencyGain = frequency;


        _startingAmplitude = amplitude;
        _startingFrequency = frequency;
        _timer = time;
        _timerTotal = time;
        _restoreTimer = 1f;
        _restoreTimerTotal = 1f;

    }

    private void Update()
    {
        CinemachineBasicMultiChannelPerlin cbcp = _cVc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (_timer > 0)
        {

            _timer -= Time.deltaTime;

            cbcp.m_AmplitudeGain = Mathf.Lerp(_startingAmplitude, 0f, 1f - (_timer / _timerTotal));
            cbcp.m_FrequencyGain = Mathf.Lerp(_startingFrequency, 0f, 1f - (_timer / _timerTotal));
        }

        if (_timer <= 0 && _restoreTimer > 0)
        {
            _restoreTimer -= Time.deltaTime;
            cbcp.m_NoiseProfile = _handCamNoiseProfile;
            cbcp.m_AmplitudeGain = Mathf.Lerp(0f, _deafultAmplitude, 1f - (_restoreTimer / _restoreTimerTotal)); ;
            cbcp.m_FrequencyGain = Mathf.Lerp(0f, _deafultFrecuency, 1f - (_restoreTimer / _restoreTimerTotal)); ;
        }
    }

}
