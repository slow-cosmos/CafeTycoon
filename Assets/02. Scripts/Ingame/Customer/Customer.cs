using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CustomerType
{
    Normal,
}

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject orderObject;
    [SerializeField] private GameObject coinObject;
    [SerializeField] private GameObject timerObject;

    [SerializeField] private List<Order> orderList = new List<Order>();
    [SerializeField] private int orderCount;

    [SerializeField] private CustomerTimer timer;
    [SerializeField] private Coin coin;

    [SerializeField] private Dialog dialog;

    private bool endFlag = false;
    public bool EndFlag => endFlag;

    private void Awake()
    {
        timer.InitTimeSpeed(1); // 노멀 손님
    }

    private void Update()
    {
        if(!endFlag)
        {
            if(timer.isEnd)
            {
                endFlag = true;
                StartCoroutine(FailOrder());
            }
            else if(orderCount == 0)
            {
                endFlag = true;
                StartCoroutine(SuccessOrder());
            }
        }
    }

    public void InitOrder(List<OrderType> order)
    {
        orderCount = order.Count;
        for(int i=0;i<order.Count;i++)
        {
            orderList[i].gameObject.SetActive(true);
            orderList[i].orderType = order[i];
        }
    }

    public bool MatchMenu(OrderType menu, int cost)
    {
        if(endFlag) return false;
        
        foreach(var order in orderList)
        {
            if(order.gameObject.activeSelf) // 활성화 된 메뉴만 확인
            {
                if(order.orderType == menu)
                {
                    orderCount--;
                    order.gameObject.SetActive(false);
                    timer.PlusTime(3);
                    coin.AddCost(cost);
                    return true;
                }
            }
        }
        StartCoroutine(WarningOrder());
        return false;
    }

    IEnumerator WarningOrder()
    {
        orderObject.SetActive(false);
        timerObject.SetActive(false);

        dialog.StartCoroutine(dialog.ChangeDialog(DialogType.Warning));
        yield return new WaitForSeconds(1);

        orderObject.SetActive(true);
        timerObject.SetActive(true);
    }

    IEnumerator SuccessOrder()
    {
        orderObject.SetActive(false);
        timerObject.SetActive(false);

        dialog.StartCoroutine(dialog.ChangeDialog(DialogType.Success));
        yield return new WaitForSeconds(1);

        coinObject.SetActive(true);
    }

    IEnumerator FailOrder()
    {
        orderObject.SetActive(false);
        timerObject.SetActive(false);

        dialog.StartCoroutine(dialog.ChangeDialog(DialogType.Fail));
        yield return new WaitForSeconds(1);

        if(coin.Cost == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            coinObject.SetActive(true);
        }
    }
}
