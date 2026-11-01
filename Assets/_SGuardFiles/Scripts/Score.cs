
using Unity.VisualScripting;

public static class Score
{
    public static int _ScoreValue = 0;

    public static void Start()
    {
        _ScoreValue = 0;
    }

    public static void AddScore(int _Amount)
    {
        _ScoreValue += _Amount;
    }
}
