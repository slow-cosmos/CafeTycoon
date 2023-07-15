using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public float timeSpeed;

    public Image gauge;

    void Start()
    {
        StartCoroutine(OrderTimer());
    }

    IEnumerator OrderTimer()
    {
        float curTime = timer;
        while(curTime > 0)
        {
            curTime -= Time.deltaTime * timeSpeed;
            gauge.fillAmount = curTime / timer;
            yield return null;

            if(curTime <= 0)
            {
                curTime = 0;
                yield break;
            }
        }
    }
}
