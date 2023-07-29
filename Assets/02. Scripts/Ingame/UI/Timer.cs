using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public delegate UniTask EndGame();
    public EndGame endGame;

    [SerializeField] private TMP_Text text;

    [SerializeField] private float time;
    [SerializeField] private float curTime;
    [SerializeField] private bool isEnd;
    public bool IsEnd => isEnd;

    private int minute;
    private int second;

    private void Awake()
    {
        time = ChapterManager.Instance.chapterData.Timer;
        curTime = time;
        isEnd = false;
    }

    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
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
                curTime = 0;
                isEnd = true;
                endGame();
                yield break;
            }
        }
    }
}
