using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public CustomerQueueData customerQueueData;

    public GameObject normalCustomer;

    public float timeGap;

    void Awake()
    {
        // 챕터 정보로 손님큐 불러오기
        timeGap = 3;
        StartCoroutine(CustomerQueueStart());
    }

    IEnumerator CustomerQueueStart()
    {
        WaitForSeconds waitTime = new WaitForSeconds(timeGap);
        for(int i=0;i<customerQueueData.CustomerCount;i++)
        {
            yield return waitTime;
            Debug.Log(i+"번째 손님 등장");
            switch(customerQueueData.CustomerList[i].customerType)
            {
                case CustomerType.Normal:
                    GameObject customer = Instantiate(normalCustomer, gameObject.transform);
                    customer.GetComponent<Customer>().InitOrder(customerQueueData.CustomerList[i].orderList);
                    break;
            }
            
        }
    }
}
