using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum RecipeType
{
    None = 0,
    Espresso = 1,
    GreenTea = 2,
    Water = 3,
    Milk = 4,
    HotMilk = 5,
    Ice = 6,
    Cream = 7
}

public abstract class Recipe : MonoBehaviour
{
    protected SpriteRenderer renderer;
    public Sprite[] sprites = new Sprite[2]; // 기본 0, 드래그 중 1
    protected Vector3 originPosition;
    [SerializeField]
    protected GameObject trigger; // 트리거 오브젝트

    [SerializeField]
    protected RecipeType recipeType;
    [SerializeField]
    protected int cost;

    public void OnMouseDrag()
    {
        renderer.sprite = sprites[1];
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
    }

    public abstract void OnMouseUp();

    protected void OnTriggerStay(Collider col)
    {
        trigger = col.gameObject;
    }

    protected void OnTriggerExit(Collider col)
    {
        trigger = null;
    }

    protected abstract bool isAddable(CupMenu cup);
}
