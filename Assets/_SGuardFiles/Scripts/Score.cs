
using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int _ScoreValue {get; private set;}

    void OnEnable()
    {
        EventManager._DusmanOldu += AddScore;
        EventManager._UpgradeGunAction += UpgradeCost;
    }

    void OnDisable()
    {
        EventManager._DusmanOldu -= AddScore;
        EventManager._UpgradeGunAction -= UpgradeCost;
    }


    public void Start()
    {
        _ScoreValue = 0;
    }

    public void AddScore(int _Amount)
    {
        _ScoreValue += _Amount;

        EventManager.SkorGuncelle(_ScoreValue);
    }
    private void UpgradeCost(int _Amount)
    {
        if(_ScoreValue >= _Amount)
        {
            _ScoreValue -= _Amount;
            EventManager.SkorGuncelle(_ScoreValue);
            EventManager.IncraseFireRate(0.1f);
        }
    }
}
