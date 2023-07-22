using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CoinScore;
    [SerializeField] private TMP_Text CoinScoreText;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        CoinScoreText.text = "Coins : " + CoinScore.ToString();
    }
}
