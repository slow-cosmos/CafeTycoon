using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CustomerType
{
    Normal,
}

public class Customer : MonoBehaviour, ICostInit, ICostAdd
{
    [SerializeField] private GameObject coinObject;
    [SerializeField] private GameObject orderObject;
    [SerializeField] private GameObject timerObject;

    [SerializeField] private List<Order> orderList = new List<Order>();
    [SerializeField] private int orderCount;

    private float time = 20;
    private float timeSpeed = 1;
    [SerializeField] private Timer timer;

    public int cost;

    void Awake()
    {
        timer.time = time;
        timer.timeSpeed = timeSpeed;
        InitCost();
    }

    void Update()
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

    public bool MatchMenu(OrderType menu)
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
                    return true;
                }
            }
        }
        Debug.Log("주문 안했어요");
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
        if(cost == 0)
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

    public void InitCost()
    {
        cost = 0;
    }

    public void AddCost(int c)
    {
        cost += c;
    }
}
