using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Enemy Sounds")]
    [SerializeField] AudioSource _EnemyDeadAudio;

    void OnEnable()
    {
        EventManager._DusmanOldu += PlayEnemyDeadAudio;
    }

    void OnDisable()
    {
        EventManager._DusmanOldu -= PlayEnemyDeadAudio;
    }

    public void PlayEnemyDeadAudio()
    {
        _EnemyDeadAudio.PlayOneShot(_EnemyDeadAudio.clip);
    }

}
