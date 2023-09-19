using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class CustomerQueue : MonoBehaviour
{
    public delegate UniTask EndGame();
    public EndGame endGame;

    public GameObject normalCustomer;

    [SerializeField] private Holder[] holders = new Holder[4]; // 손님 좌석

    [SerializeField] private float timeGap;
    [SerializeField] private float curTime;

    [SerializeField] private Image gauge;
    [SerializeField] private TMP_Text queueText;

    private Coroutine coroutine;

    private void Awake()
    {
        timeGap = ChapterManager.Instance.chapterData.TimeGap;
        curTime = timeGap;
    }
    
    private void OnEnable()
    {
        coroutine = StartCoroutine(StartCustomerQueue());
    }

    private IEnumerator StartCustomerQueue()
    {
        for(int i=0;i<ChapterManager.Instance.customerQueueData.CustomerList.Count;i++)
        {
            while(curTime > 0)
            {
                curTime -= Time.deltaTime;
                gauge.fillAmount = (timeGap - curTime) / timeGap;
                queueText.text = $"{i+1}/{ChapterManager.Instance.customerQueueData.CustomerList.Count}";
                yield return null;
            }
            curTime = timeGap;

            while(true)
            {
                Holder seat = GetEmptySeat();
                if(GetEmptySeat() == null)
                {
                    yield return null;
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
        StartCoroutine(WaitForEndCustomerQueue());
    }

    private Holder GetEmptySeat() // 빈자리 찾기
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

    private void ComeInCustomer(Holder seat, CustomerType customerType, List<OrderType> orderList)
    {
        SoundManager.Instance.PlayEffect("guestin");
        switch(customerType)
        {
            case CustomerType.Normal:
                GameObject customer = Instantiate(normalCustomer, seat.gameObject.transform);
                seat.Object = customer;
                customer.GetComponent<Customer>().InitOrder(orderList);
                break;
        }
    }

    private IEnumerator WaitForEndCustomerQueue() // 손님이 모두 나갈 때까지 대기
    {
        for(int i=0;i<4;i++)
        {
            while(holders[i].Object != null && holders[i].Object.GetComponent<Customer>().EndFlag == false)
            {
                // Debug.Log(i+" 손님 나갈 때까지 대기");
                yield return null;
            }
        }
        Debug.Log("모두 나감");
        yield return new WaitForSeconds(1);

        endGame().Forget();
    }

    private async UniTask ComeOutCustomer() // 손님 내보내기
    {
        for(int i=0;i<4;i++)
        {
            if(holders[i].Object != null && holders[i].Object.GetComponent<Customer>().EndFlag == false)
            {
                Customer customer = holders[i].Object.GetComponent<Customer>();
                customer.FailOrder().Forget();
            }
        }
    }

    public async UniTask EndCustomerQueue()
    {
        StopCoroutine(coroutine); // 손님큐 멈추기
        await ComeOutCustomer();
    }

    public async UniTask GetAllCoin() // 끝날 때 받지 않은 돈을 받음
    {
        for(int i=0;i<4;i++) // 자리를 돌면서
        {
            if(holders[i].Object != null && holders[i].Object.GetComponent<Customer>().EndFlag) // 돈을 받지 않은 손님이 있으면
            {
                await holders[i].Object.transform.Find("CoinImage").GetComponent<CoinView>().AddCoin(); // 돈 받기
            }
        }
    }
}
