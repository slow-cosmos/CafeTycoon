using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BakedType
{
    Baked,
    Burned
}

public enum DoughType
{
    Cookie,
    Doughnut
}

public abstract class DoughMenu : MonoBehaviour, ICostInit
{
    protected Vector3 originPosition;
    [SerializeField] private GameObject trigger; // 트리거 오브젝트

    [SerializeField] private DoughType doughType;
    public DoughType Dough
    {
        get
        {
            return doughType;
        }
    }

    public Sprite[] sprites = new Sprite[2];
    [SerializeField] private BakedType bakedType;
    public BakedType Baked
    {
        get
        {
            return bakedType;
        }
        set
        {
            bakedType = value;
            GetComponent<SpriteRenderer>().sprite = sprites[(int)bakedType];
        }
    }

    public int cost;
    public OrderType menu;

    public abstract void InitCost();

    public void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
    }

    public void OnMouseUp()
    {
        if(trigger != null) 
        {
            if(trigger.CompareTag("Customer"))
            {
                if(bakedType == BakedType.Baked) // 타지 않았으면
                {
                    Customer customer = trigger.GetComponent<Customer>();
                    if(customer.MatchMenu(menu, cost))
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Debug.Log("탄걸 왜 줌");
                }
            }
            if(trigger.CompareTag("Trash"))
            {
                Destroy(gameObject);
            }
            transform.position = originPosition;
        }
        else
        {
            transform.position = originPosition;
        }
    }

    protected void OnTriggerStay(Collider col)
    {
        trigger = col.gameObject;
    }

    protected void OnTriggerExit(Collider col)
    {
        trigger = null;
    }
}