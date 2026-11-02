using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TMPro.TextMeshProUGUI _ScoreText;
    [SerializeField] Score _ScoreManager;


    void OnEnable()
    {
        EventManager._SkorGuncelleAction += UpdateScore;
    }

    void OnDisable()
    {
        EventManager._SkorGuncelleAction -= UpdateScore;
    }

    void Start()
    {
        UpdateScore(_ScoreManager._ScoreValue);
    }

    void UpdateScore(int _Amount)
    {
        _ScoreText.text = $"SCORE: {_Amount}";
    }
}
