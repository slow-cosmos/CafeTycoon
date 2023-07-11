using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoughType
{
    Cookie,
    Doughnut
}

public class Dough : MonoBehaviour
{
    public GameObject doughObject; // 만들어진 도우

    protected SpriteRenderer renderer;
    public Sprite[] sprites = new Sprite[2]; // 기본 0, 드래그 중 1
    protected Vector3 originPosition;
    [SerializeField]
    protected GameObject trigger; // 트리거 오브젝트

    [SerializeField]
    protected DoughType doughType;

    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        originPosition = transform.position;
    }

    public void OnMouseDrag()
    {
        renderer.sprite = sprites[1];
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
    }

    public void OnMouseUp()
    {
        if(trigger != null && trigger.CompareTag("Oven")) 
        {
            Oven oven = trigger.GetComponent<Oven>();
            oven.dough = doughObject;
            oven.MakeMenu();
        }
        renderer.sprite = sprites[0];
        transform.position = originPosition;
    }

    private void OnTriggerStay(Collider col)
    {
        trigger = col.gameObject;
    }

    private void OnTriggerExit(Collider col)
    {
        trigger = null;
    }
}
