using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Cue", menuName = "Scriptable Objects/AudioCueSO", order = 1)]
public class AudioCueSO : ScriptableObject
{
    public AudioClip _AudioClip;

    [Range(0f, 1f)]
    public float _Volume = 1f;

    [Header("Rastgele Ses Tonu")]
    public bool _UseRandomPitch = true;
    public float _MinPitch = 0.9f;
    public float _MaxPitch = 1.1f;
}
