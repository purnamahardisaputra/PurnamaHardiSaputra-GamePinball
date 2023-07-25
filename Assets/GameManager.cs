using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CoinScore, Health;
    public static GameManager instance;
    [SerializeField] private TMP_Text CoinScoreText, HealthText, HighScoreText;
    [SerializeField] GameObject GameOverPanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        CoinScoreText.text = "Coins : " + CoinScore.ToString();
        HealthText.text = "Health : " + Health.ToString();

        if (Health <= 0)
        {
            GameOverPanel.SetActive(true);
            HighScoreText.text = PlayerPrefs.GetInt("CoinScore").ToString();
            Health = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
