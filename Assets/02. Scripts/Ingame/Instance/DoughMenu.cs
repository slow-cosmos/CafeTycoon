using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BakedType
{
    Baked,
    Burned
}

public abstract class DoughMenu : MonoBehaviour, ICostInit
{
    protected Vector3 originPosition;
    [SerializeField] private GameObject trigger; // 트리거 오브젝트

    public Sprite[] sprites = new Sprite[2];
    [SerializeField] private BakedType bakedType;

    public int cost;

    public abstract void InitCost();

    public void SetBakedType(BakedType type)
    {
        bakedType = type;
        GetComponent<SpriteRenderer>().sprite = sprites[(int)bakedType];
    }

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
                    Sprite sprite = GetComponent<SpriteRenderer>().sprite;
                    Customer customer = trigger.GetComponent<Customer>();
                    if(customer.MatchMenu(sprite))
                    {
                        customer.AddCost(cost);
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