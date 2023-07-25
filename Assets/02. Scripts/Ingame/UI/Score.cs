using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private static Score instance;
    public static Score Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private Image gauge;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private int curScore;

    [SerializeField] private int star1Score;
    [SerializeField] private int star2Score;
    [SerializeField] private int star3Score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        curScore = 0;

        scoreText.text = "0";
        gauge.fillAmount = 0;

        star1Score = 50; // 임시
        star2Score = 70;
        star3Score = 100;
    }

    public void AddScore(int coin)
    {
        curScore += coin;

        scoreText.text = curScore.ToString();
        gauge.fillAmount = curScore >= star3Score ? 1 : (float)curScore / (float)star3Score;
    }
}
