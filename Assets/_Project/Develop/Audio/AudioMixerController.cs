using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class AudioMixerController : MonoBehaviour
{
    private const string SoundVolumeKey = "SoundVolume";
    private const string AmbientVolumeKey = "AmbientVolume";

    private const string _onText = "On";
    private const string _offText = "Off";

    private const float _onVolume = 0f;
    private const float _offVolume = -80f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private TMP_Text _ambientText;
    [SerializeField] private TMP_Text _soundText;

    private bool _soundEnabled = true;
    private bool _ambientEnabled = true;

    public void AmbientVolumeChanged()
    {
        if (_ambientEnabled)
        {
            _audioMixer.SetFloat(AmbientVolumeKey, _offVolume);
            _ambientEnabled = false;
        }
        else
        {
            _audioMixer.SetFloat(AmbientVolumeKey, _onVolume);
            _ambientEnabled = true;
        }

        _ambientText.text = "Ambient: " + (_ambientEnabled ? _onText : _offText);
    }

    public void SoundVolumeChanged()
    {
        if (_soundEnabled)
        {
            _audioMixer.SetFloat(SoundVolumeKey, _offVolume);
            _soundEnabled = false;
        }
        else
        {
            _audioMixer.SetFloat(SoundVolumeKey, _onVolume);
            _soundEnabled = true;
        }

        _soundText.text = "Sound: " + (_soundEnabled ? _onText : _offText);
    }
}
