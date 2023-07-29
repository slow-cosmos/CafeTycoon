using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
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

    [SerializeField] private bool endFlag = false;
    public bool EndFlag => endFlag;

    private void Awake()
    {
        timer.InitTimeSpeed(0.7f); // 노멀 손님
    }

    private async void Update()
    {
        if(!endFlag)
        {
            if(timer.isEnd)
            {
                FailOrder().Forget();
            }
            else if(orderCount == 0)
            {
                SuccessOrder().Forget();
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
        WarningOrder().Forget();
        return false;
    }

    private async UniTask WarningOrder()
    {
        orderObject.SetActive(false);
        timerObject.SetActive(false);

        await dialog.ChangeDialog(DialogType.Warning);

        orderObject.SetActive(true);
        timerObject.SetActive(true);
    }

    private async UniTask SuccessOrder()
    {
        endFlag = true;
        
        orderObject.SetActive(false);
        timerObject.SetActive(false);

        await dialog.ChangeDialog(DialogType.Success);

        coinObject.SetActive(true);
    }

    public async UniTask FailOrder()
    {
        endFlag = true;

        orderObject.SetActive(false);
        timerObject.SetActive(false);

        await dialog.ChangeDialog(DialogType.Fail);

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
