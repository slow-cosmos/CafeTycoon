using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text stage;
    [SerializeField] private TMP_Text score;
    [SerializeField] private Image star;

    private void OnEnable()
    {
        stage.text = "Stage " + ChapterManager.Instance.CurChapter.ToString();
        score.text = Score.Instance.CurScore.ToString();
        // 별 이미지 추가
    }
}
