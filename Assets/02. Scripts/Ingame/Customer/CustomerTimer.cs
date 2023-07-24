using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerTimer : MonoBehaviour
{
    [SerializeField] private Image gauge;

    private float time = 20;
    private float timeSpeed;

    private float curTime;

    public bool isEnd;

    private void Awake()
    {
        isEnd = false;
        curTime = time;
    }

    private void OnEnable()
    {
        StartCoroutine(OrderTimer());
    }

    IEnumerator OrderTimer()
    {
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

    public void InitTimeSpeed(float speed)
    {
        timeSpeed = speed;
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
