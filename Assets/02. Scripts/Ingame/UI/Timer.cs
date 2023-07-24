using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private float time;
    [SerializeField] private float curTime;

    int minute;
    int second;

    private void Awake()
    {
        time = 70;
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
                curTime = 0;
                yield break;
            }
        }
    }
}
