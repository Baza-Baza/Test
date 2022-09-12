using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuView : View
{
    [Header("Set in Inspector")]
    [SerializeField]
    private Button _startBtn;
    [SerializeField]
    private Button _quitBtn;
    [SerializeField]
    private TextMeshProUGUI _textTotalScore;

    protected override void Initialize()
    {
        base.Initialize();

        _startBtn.onClick.AddListener(StartGame);
        _quitBtn.onClick.AddListener(QuitGame);

        UpdateTotalScore();
    }

    protected override void Disable()
    {
        base.Disable();

        _startBtn.onClick.RemoveAllListeners();
        _quitBtn.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        MainMenuManager.Instance.StartGame();
    }

    private void QuitGame()
    {
        MainMenuManager.Instance.QuitGame();
    }

    private void UpdateTotalScore()
    {
        _textTotalScore.text = "Best Score: " + MainMenuManager.Instance.TottalScore.ToString();
    }
}
