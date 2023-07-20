using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dough : MonoBehaviour
{
    public GameObject doughObject; // 구운 반죽

    private BoxCollider collider;
    private SpriteRenderer renderer;
    public Sprite sprite;
    Vector3 originPosition;
    [SerializeField] private GameObject trigger; // 트리거 오브젝트

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
        renderer = GetComponent<SpriteRenderer>();
        originPosition = transform.position;
    }

    public void OnMouseDrag()
    {
        renderer.sprite = sprite;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
        ChangeColliderSize(1.02f, 0.8f);
    }

    public void OnMouseUp()
    {
        if(trigger != null && trigger.CompareTag("Oven")) 
        {
            Oven oven = trigger.GetComponent<Oven>();
            oven.MakeMenu(doughObject);
        }
        renderer.sprite = null;
        transform.position = originPosition;
        ChangeColliderSize(1.96f, 0.99f);
    }

    private void OnTriggerStay(Collider col)
    {
        trigger = col.gameObject;
    }

    private void OnTriggerExit(Collider col)
    {
        trigger = null;
    }

    void ChangeColliderSize(float x, float y)
    {
        collider.size = new Vector3(x, y, 0);
    }
}
