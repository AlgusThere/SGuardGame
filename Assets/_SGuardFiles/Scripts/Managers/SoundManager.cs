using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]  AudioSource _sfxSource;
    [SerializeField]  AudioEventChannelSO _sfxChannel;

    void OnEnable()
    {
        if(_sfxChannel != null)
            _sfxChannel._OnAudioPlayRequested += PlayAudioCue;
    }

    void OnDisable()
    {
        if(_sfxChannel != null)
            _sfxChannel._OnAudioPlayRequested -= PlayAudioCue;
    }

    void PlayAudioCue(AudioCueSO _AudioCueSO)
    {
        _sfxSource.pitch = _AudioCueSO._UseRandomPitch ? Random.Range(_AudioCueSO._MinPitch, _AudioCueSO._MaxPitch) : 1f;

        _sfxSource.PlayOneShot(_AudioCueSO._AudioClip, _AudioCueSO._Volume);
    }

}
