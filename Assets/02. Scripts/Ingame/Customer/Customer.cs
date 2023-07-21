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

    private void Awake()
    {
        timer.InitTimeSpeed(1); // 노멀 손님
    }

    private void Update()
    {
        if(timer.isEnd)
        {
            FailOrder();
        }
        else if(orderCount == 0)
        {
            SuccessOrder();
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
        foreach(var order in orderList)
        {
            if(order.gameObject.activeSelf) // 활성화 된 메뉴만 확인
            {
                if(order.orderType == menu)
                {
                    order.gameObject.SetActive(false);
                    orderCount--;
                    timer.PlusTime(3);
                    coin.AddCost(cost);
                    return true;
                }
            }
        }
        Debug.Log("주문 안했어요");
        dialog.ChangeDialog(DialogType.Warning);
        return false;
    }

    void SuccessOrder()
    {
        coinObject.SetActive(true);
        orderObject.SetActive(false);
        timerObject.SetActive(false);
    }

    void FailOrder()
    {
        dialog.ChangeDialog(DialogType.Warning);
        if(coin.Cost == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            coinObject.SetActive(true);
            orderObject.SetActive(false);
            timerObject.SetActive(false);
        }
    }
}
