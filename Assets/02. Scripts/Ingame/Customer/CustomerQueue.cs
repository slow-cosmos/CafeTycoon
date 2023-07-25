using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public GameObject normalCustomer;

    public Holder[] holders = new Holder[4]; // 손님 좌석

    [SerializeField] private float timeGap;
    [SerializeField] private float curTime;

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
        for(int i=0;i<ChapterManager.Instance.customerQueueData.CustomerList.Count;i++)
        {
            while(curTime > 0)
            {
                curTime -= Time.deltaTime;
                yield return null;
            }
            curTime = timeGap;
            // 기다렸다가 들어오는 손님 기다렸다가 들어오도록 수정

            WaitForSeconds checkTime = new WaitForSeconds(0.1f);
            while(true)
            {
                Holder seat = GetEmptySeat();
                if(GetEmptySeat() == null)
                {
                    yield return checkTime;
                }
                else
                {
                    CustomerType customerType = ChapterManager.Instance.customerQueueData.CustomerList[i].customerType;
                    List<OrderType> orderList = ChapterManager.Instance.customerQueueData.CustomerList[i].orderList;
                    ComeInCustomer(seat, customerType, orderList);
                    break;
                }
            }
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

    void ComeInCustomer(Holder seat, CustomerType customerType, List<OrderType> orderList)
    {
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
