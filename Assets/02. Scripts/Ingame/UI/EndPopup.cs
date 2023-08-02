using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private List<GameObject> starObject = new List<GameObject>();

    private void OnEnable()
    {
        Time.timeScale = 0;
        stageText.text = "Stage " + ChapterManager.Instance.CurChapter.ToString();
        scoreText.text = Score.Instance.CurScore.ToString();

        for(int i=0;i<Score.Instance.CurStar;i++)
        {
            starObject[i].SetActive(true);
        }

        SaveManager.Instance.StageClear(ChapterManager.Instance.CurChapter, Score.Instance.CurStar);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }
}
