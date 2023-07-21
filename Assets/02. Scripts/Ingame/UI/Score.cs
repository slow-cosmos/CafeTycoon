using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        gauge.fillAmount = 0;

        star3Score = 100; // 임시
    }

    public void FillScoreGauge(int coin)
    {
        curScore += coin;
        gauge.fillAmount = curScore >= star3Score ? 1 : (float)curScore / (float)star3Score;
    }
}
