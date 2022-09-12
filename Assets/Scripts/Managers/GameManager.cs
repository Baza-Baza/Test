using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public Action<int> Points
    {
        get;
        set;
    }

    public Action Health
    {
        get;
        set;
    }


    [Header("Set in Inspector")]
    [SerializeField]
    private Score _scoreGame;
    [SerializeField]
    private InstantiateFruit _instantiateFruit;
    [SerializeField]
    private Health _healthPlayer;
    [SerializeField]
    private ResultPanel _resultPanel;
    [SerializeField]
    private List<EnemyController> _enemies;

    private int _score;
    private int _bestScore;
    private int _health;

    private void Awake()
    {
        _instance = this;
        InitializeGame();

        Points += GenerateFruit;
        _resultPanel.RestartGameAction += RestartGame;
    }

    private void OnDisable()
    {
        SaveScore();
        Points -= GenerateFruit;
        _resultPanel.RestartGameAction -= RestartGame;
    }

    public void UpdateScore(int score)
    {
        _score += score;
        _scoreGame.UpdateScore(_score);

        if (_bestScore < _score)
        {
            UpdateBestScore(_score);
        }
    }

    public void TakeDamage()
    {
        _health--;
        if (_health == 0)
        {
            Health.Invoke();
            MoveEnemies(null);
            SaveScore();
            ResultPanel();
        }

        _healthPlayer.TakeDamage(_health);

    }

    private void InitializeGame()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            UpdateBestScore(PlayerPrefs.GetInt("BestScore", 0));
        }
        else
        {
            _scoreGame.UpdateBestScore(0);
        }

        _scoreGame.UpdateScore(0);
        _health = 3;

        MoveEnemies(false);
    }

    private void UpdateBestScore(int score)
    {
        _bestScore = score;
        _scoreGame.UpdateBestScore(_bestScore);
    }

    private void GenerateFruit(int value)
    {
        _instantiateFruit.GenerateFruit(value);
    }

    private void MoveEnemies(bool? value)
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].NeedToGo = value;
        }
    }

    private void ResultPanel()
    {
        _resultPanel.gameObject.SetActive(true);

        if (PlayerPrefs.HasKey("BestScore"))
        {
            _resultPanel.UpdateScore(PlayerPrefs.GetInt("BestScore", 0));
        }
        else
        {
            _resultPanel.UpdateScore(0);
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("BestScore", _bestScore);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
