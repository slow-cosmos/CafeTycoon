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
    [SerializeField] private List<Order> orderList = new List<Order>();
    [SerializeField] private int orderCount;

    private float time = 20;
    private float timeSpeed = 1;
    [SerializeField] private Timer timer;

    void Awake()
    {
        timer.time = time;
        timer.timeSpeed = timeSpeed;
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
                    orderCount--;
                    return true;
                }
            }
        }
        Debug.Log("주문 안했어요");
        return false;
    }

    void SuccessOrder()
    {
        Debug.Log("주문 성공");
        Destroy(gameObject);
    }

    void FailOrder()
    {
        Debug.Log("주문 실패");
        Destroy(gameObject);
    }
}
