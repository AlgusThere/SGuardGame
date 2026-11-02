
using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int _ScoreValue {get; private set;}

    void OnEnable()
    {
        EventManager._DusmanOldu += AddScore;
    }

    void OnDisable()
    {
        EventManager._DusmanOldu -= AddScore;
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
}
