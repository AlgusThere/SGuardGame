using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AudioEventChannelSO", menuName = "Scriptable Objects/AudioEventChannelSO")]
public class AudioEventChannelSO : ScriptableObject
{
    public event Action<AudioCueSO>  _OnAudioPlayRequested;

    public void RaisePlayEvent(AudioCueSO _AudioCue)
    {
        if(_AudioCue != null)
        {
            _OnAudioPlayRequested?.Invoke(_AudioCue);
        }
    }
}
