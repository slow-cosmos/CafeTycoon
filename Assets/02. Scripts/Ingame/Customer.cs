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
    public CustomerData customerData;

    [SerializeField]
    List<Order> orderList = new List<Order>();

    [SerializeField]
    Timer timer;

    void Awake()
    {
        timer.timer = customerData.Timer;
        timer.timeSpeed = customerData.TimeSpeed;
    }

    public void InitOrder(List<OrderType> order)
    {
        for(int i=0;i<order.Count;i++)
        {
            orderList[i].gameObject.SetActive(true);
            orderList[i].orderType = order[i];
        }
    }

    public bool MatchMenu(Sprite menu)
    {
        // 현재 스프라이트가 같은지 판별해서 처리 중 -> 어떻게 바꿀지 생각
        foreach(var order in orderList)
        {
            if(order.gameObject.activeSelf) // 활성화 된 메뉴만 확인
            {
                Sprite sprite = order.GetComponent<Image>().sprite;
                if(sprite == menu)
                {
                    order.gameObject.SetActive(false);
                    return true;
                }
            }
        }
        Debug.Log("주문 안했어요");
        return false;
    }

    void SuccessOrder()
    {
        
    }

    void FailOrder()
    {

    }
}
