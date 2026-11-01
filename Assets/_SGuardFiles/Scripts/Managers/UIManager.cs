using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI _ScoreText;

    void OnEnable()
    {
        EventManager._DusmanOldu += UpdateScore;
    }

    void OnDisable()
    {
        EventManager._DusmanOldu -= UpdateScore;
    }

    void UpdateScore()
    {
        Score.AddScore(10);
        _ScoreText.text = "SCORE: " + Score._ScoreValue.ToString();
    }
}
