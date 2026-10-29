using System.Collections;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string _WaveName;
    public GameObject _EnemyPrefab;
    public int _EnemyCount;
    public float _SpawnRate;
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] Wave[] _Waves;
    
    private int _CurrentWaveIndex = 0;
    private bool _IsWaveActive;

    public void StartNextWave()
    {
        if(_IsWaveActive || _CurrentWaveIndex >= _Waves.Length)
        {
            return;
        }

        StartCoroutine(SpawnWaveRoutine());
    }

    private IEnumerator SpawnWaveRoutine()
    {
        _IsWaveActive = true;

        Wave _CurrentWave = _Waves[_CurrentWaveIndex];

        for (int i = 0; i < _CurrentWave._EnemyCount; i++)
        {
            Instantiate(_CurrentWave._EnemyPrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(_CurrentWave._SpawnRate);
        }

        while(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            yield return new WaitForSeconds(1f);
        }

        _CurrentWaveIndex++;
        _IsWaveActive = false;
    }
}
