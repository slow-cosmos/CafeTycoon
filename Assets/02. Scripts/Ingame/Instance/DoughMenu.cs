using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BakedType
{
    Baked,
    Burned
}

public class DoughMenu : MonoBehaviour
{
    protected Vector3 originPosition;
    [SerializeField]
    GameObject trigger; // 트리거 오브젝트

    [SerializeField]
    protected int cost;

    public Sprite[] sprites = new Sprite[2];
    [SerializeField]
    BakedType bakedType;

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
                    if(trigger.GetComponent<Customer>().MatchMenu(sprite))
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