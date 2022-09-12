using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultPanel : View
{
    public Action RestartGameAction
    {
        get;
        set;
    }

    [SerializeField]
    private TextMeshProUGUI _bestScore;
    [SerializeField]
    private Button _restartBtn;

    protected override void Initialize()
    {
        base.Initialize();

        _restartBtn.onClick.AddListener(RestartGame);
    }

    protected override void Disable()
    {
        base.Disable();

        _restartBtn.onClick.RemoveAllListeners();
    }

    public void UpdateScore(int score)
    {
        _bestScore.text = "Best score: " + score.ToString();
    }

    private void RestartGame()
    {
        RestartGameAction.Invoke();
    }
}
