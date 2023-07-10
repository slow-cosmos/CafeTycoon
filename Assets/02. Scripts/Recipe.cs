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

public class Recipe : MonoBehaviour
{
    SpriteRenderer renderer;
    public Sprite[] sprites = new Sprite[2]; // 기본 0, 드래그 중 1
    Vector3 originPosition;
    [SerializeField]
    GameObject trigger; // 트리거 오브젝트

    [SerializeField]
    RecipeType recipeType;
    [SerializeField]
    int cost;

    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        originPosition = transform.position;

        cost = 5; // 가격 불러오는 걸로 갱신
    }

    public void OnMouseDrag()
    {
        renderer.sprite = sprites[1];
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));

    }

    public void OnMouseUp()
    {
        if(trigger != null)
        {
            CupMenu cup = trigger.GetComponent<CupMenu>();
            if(trigger.CompareTag("Cup"))
            {
                if(cup.AddRecipe(recipeType))
                {
                    if(recipeType == RecipeType.Espresso || recipeType == RecipeType.HotMilk)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        renderer.sprite = sprites[0];
                        transform.position = originPosition;
                    }
                }
                else
                {
                    renderer.sprite = sprites[0];
                    transform.position = originPosition;
                }
            }
            else if(trigger.CompareTag("Trash"))
            {
                if(recipeType == RecipeType.Espresso || recipeType == RecipeType.HotMilk)
                {
                    Destroy(gameObject);
                }
                else
                {
                    renderer.sprite = sprites[0];
                    transform.position = originPosition;
                }
            }
            else if(trigger.CompareTag("SteamMachine"))
            {

            }
        }
        else
        {
            renderer.sprite = sprites[0];
            transform.position = originPosition;
        } 
    }

    private void OnTriggerEnter(Collider col)
    {
        trigger = col.gameObject;
    }

    private void OnTriggerExit(Collider col)
    {
        trigger = null;
    }
}
