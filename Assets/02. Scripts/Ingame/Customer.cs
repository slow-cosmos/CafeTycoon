using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public CustomerData customerData;

    public int orderCount;

    [SerializeField]
    List<GameObject> orderList = new List<GameObject>();

    [SerializeField]
    Timer timer;

    void Awake()
    {
        for(int i=orderCount;i<3;i++)
        {
            orderList[i].SetActive(false);
        }
        timer.timer = customerData.Timer;
        timer.timeSpeed = customerData.TimeSpeed;
    }

    public bool MatchMenu(Sprite menu)
    {
        // 현재 스프라이트가 같은지 판별해서 처리 중 -> 어떻게 바꿀지 생각
        foreach(var order in orderList)
        {
            if(order.activeSelf) // 활성화 된 메뉴만 확인
            {
                Sprite sprite = order.GetComponent<Image>().sprite;
                if(sprite == menu)
                {
                    order.SetActive(false);
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
