using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image gauge;

    public float time;
    public float timeSpeed;

    private float curTime;

    public bool isEnd;

    void Start()
    {
        isEnd = false;
        StartCoroutine(OrderTimer());
    }

    IEnumerator OrderTimer()
    {
        curTime = time;
        while(curTime > 0)
        {
            curTime -= Time.deltaTime * timeSpeed;
            gauge.fillAmount = curTime / time;
            yield return null;

            if(curTime <= 0)
            {
                isEnd = true;
                curTime = 0;
                yield break;
            }
        }
    }

    public void PlusTime(float plus)
    {
        curTime += plus;
        if(curTime>time)
        {
            curTime = time;
        }
    }
}
