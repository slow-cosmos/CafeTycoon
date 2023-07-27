using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PausePopup : MonoBehaviour
{
    [SerializeField] private TMP_Text stage;

    private void Awake()
    {
        stage.text = "Stage " + ChapterManager.Instance.CurChapter.ToString();
    }  

    private void OnEnable()
    {
        Time.timeScale = 0;
        //손님 주문 안보이게
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        //손님 주문 보이게
        gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }
}
