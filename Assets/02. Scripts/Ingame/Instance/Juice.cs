using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour
{
    private Vector3 originPosition;
    [SerializeField]
    GameObject trigger; // 트리거 오브젝트

    [SerializeField]
    private int cost;

    void Awake()
    {
        originPosition = transform.position;
        cost = 5; // 가격 불러오는 걸로 갱신
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
                Sprite sprite = GetComponent<SpriteRenderer>().sprite;
                if(trigger.GetComponent<Customer>().MatchMenu(sprite))
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
