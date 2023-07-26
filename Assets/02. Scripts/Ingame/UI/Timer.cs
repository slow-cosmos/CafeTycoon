using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public delegate void EndGame();
    public EndGame endGame;

    [SerializeField] private TMP_Text text;

    [SerializeField] private float time;
    [SerializeField] private float curTime;

    int minute;
    int second;

    private void Awake()
    {
        time = ChapterManager.Instance.chapterData.Timer;
        curTime = time;
    }

    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while(curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            text.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if(curTime <= 0)
            {
                Debug.Log("시간 종료");
                endGame();
                curTime = 0;
                yield break;
            }
        }
    }
}
