using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public GameObject normalCustomer;

    public CustomerQueueData customerQueueData;

    public Holder[] holders = new Holder[4]; // 손님 좌석

    public float timeGap;
    public float curTime;

    private void Awake()
    {
        // 챕터 정보로 손님큐 불러오기
        timeGap = 3;
        curTime = timeGap;
    }
    
    private void OnEnable()
    {
        StartCoroutine(CustomerQueueStart());
    }

    IEnumerator CustomerQueueStart()
    {
        //WaitForSeconds waitTime = new WaitForSeconds(timeGap);
        for(int i=0;i<customerQueueData.CustomerList.Count;i++)
        {
            //yield return waitTime;
            while(curTime > 0)
            {
                curTime -= Time.deltaTime;
                yield return null;
            }
            curTime = timeGap;
            // 기다렸다가 들어오는 손님 기다렸다가 들어오도록 수정
            
            CustomerType customerType = customerQueueData.CustomerList[i].customerType;
            List<OrderType> orderList = customerQueueData.CustomerList[i].orderList;
            StartCoroutine(ComeInCustomer(customerType, orderList));
        }
    }

    Holder GetEmptySeat() // 빈자리 찾기
    {
        for(int i=0;i<4;i++)
        {
            if(holders[i].Object == null)
            {
                return holders[i];
            }
        }
        return null;
    }

    IEnumerator ComeInCustomer(CustomerType customerType, List<OrderType> orderList)
    {
        WaitForSeconds checkTime = new WaitForSeconds(0.1f);
        while(GetEmptySeat() == null)
        {
            yield return checkTime;
        }
        
        Holder seat = GetEmptySeat();

        switch(customerType)
        {
            case CustomerType.Normal:
                GameObject customer = Instantiate(normalCustomer, seat.gameObject.transform);
                customer.GetComponent<Customer>().InitOrder(orderList);
                seat.Object = customer;
                break;
        }
    }
}
