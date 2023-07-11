using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotMilk : Recipe
{
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        originPosition = transform.position;

        cost = 5; // 가격 불러오는 걸로 갱신
    }

    public override void OnMouseUp()
    {
        if(trigger != null)
        {
            if(trigger.CompareTag("Cup")) 
            {
                CupMenu cup = trigger.GetComponent<CupMenu>();
                if(isAddable(cup)) // 컵에 추가할 수 있으면
                {
                    cup.SetIngredients(IngredientType.Sub, recipeType);
                    cup.AddCost(cost);
                    Destroy(gameObject);
                }
                else
                {
                    renderer.sprite = sprites[0];
                    transform.position = originPosition;
                }
            }
            else if(trigger.CompareTag("Trash"))
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

    protected override bool isAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.GetIngredients();
        if(cup.cupType == CupType.MugCup &&
            ingredients[IngredientType.Sub] == RecipeType.None)
        {
            return true;
        }
        return false;
    }
}
