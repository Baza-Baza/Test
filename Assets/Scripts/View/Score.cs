using UnityEngine;
using TMPro;

public class Score : View
{
    [Header("Set in Inspector")]
    [SerializeField]
    private TextMeshProUGUI _textCurrentScore;
    [SerializeField]
    private TextMeshProUGUI _textBestScore;

    public  void UpdateScore(int value)
    {
        _textCurrentScore.text = "Score: " + value.ToString();
    }

    public void UpdateBestScore(int value)
    {
        _textBestScore.text = "Best score: " + value.ToString();
    }
}
