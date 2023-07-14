using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public CustomerData customerData;

    public int orderCount;

    [SerializeField]
    List<GameObject> orderList = new List<GameObject>();

    void Awake()
    {
        for(int i=orderCount;i<3;i++)
        {
            orderList[i].SetActive(false);
        }
    }

    public bool MatchMenu(Sprite menu)
    {
        foreach(var order in orderList)
        {
            if(order.activeSelf) // 활성화 된 메뉴만 확인
            {
                Sprite sprite = order.GetComponent<SpriteRenderer>().sprite;
                if(sprite == menu)
                {
                    order.SetActive(false);
                    return true;
                }
            }
        }
        return false;
    }

}
