using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance { get { return instance; } }
    private static MainMenuManager instance;

    public int TottalScore
    {
        get 
        {
            if (PlayerPrefs.HasKey("BestScore"))
            {
                return PlayerPrefs.GetInt("BestScore");
            }
            else
            {
                return 0;
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
