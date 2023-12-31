using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour, ICostInit
{
    private Vector3 originPosition;
    [SerializeField] private GameObject trigger; // 트리거 오브젝트

    [SerializeField] private int cost;
    public OrderType menu;

    void Awake()
    {
        originPosition = transform.position;

        InitCost();
        
        menu = OrderType.Juice;
    }

    public void InitCost()
    {
        cost = UpgradeManager.Instance.GetUpgrade("Juice:Cost");
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
                Customer customer = trigger.GetComponent<Customer>();
                if(customer.MatchMenu(menu, cost))
                {
                    Destroy(gameObject);
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
