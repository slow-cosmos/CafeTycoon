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

    [SerializeField] private int curScore;
    public int CurScore => curScore;

    [SerializeField] private int curStar;
    public int CurStar => curStar;

    [SerializeField] private Image gauge;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private List<Image> starImage;
    [SerializeField] private Sprite fillStar;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        curScore = 0;
        ViewScore();

        curStar = 0;
        for(int i=0;i<3;i++) // 별 위치 초기화
        {
            starImage[i].rectTransform.anchoredPosition = new Vector3((float)ChapterManager.Instance.chapterData.StarScore[i] / (float)ChapterManager.Instance.chapterData.StarScore[2] * gauge.rectTransform.rect.width, 3, 0);
        }
    }

    private void ViewStar() // 별 오브젝트
    {
        for(int i=curStar;i<3;i++)
        {
            if(curScore >= ChapterManager.Instance.chapterData.StarScore[i])
            {
                starImage[i].sprite = fillStar;
                curStar++;
            }
        }
    }

    private void ViewScore() // 점수 텍스트, 게이지 
    {
        scoreText.text = curScore.ToString();
        gauge.fillAmount = curScore >= ChapterManager.Instance.chapterData.StarScore[2] ? 1 : (float)curScore / (float)ChapterManager.Instance.chapterData.StarScore[2];
    }

    public void AddScore(int coin)
    {
        curScore += coin;

        ViewScore();
        ViewStar();
    }   
}
