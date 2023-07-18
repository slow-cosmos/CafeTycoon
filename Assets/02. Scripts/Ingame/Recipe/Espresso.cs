using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espresso : Recipe
{
    protected override void Awake()
    {
        base.Awake();
        InitCost();
    }

    public override void InitCost()
    {
        // 업그레이드 정보에 맞춰 가격 초기화
        cost = 5;
    }

    public override void OnMouseUp()
    {
        if(trigger != null)
        {
            if(trigger.CompareTag("Cup")) 
            {
                CupMenu cup = trigger.GetComponent<CupMenu>();
                if(IsAddable(cup)) // 컵에 추가할 수 있으면
                {
                    cup.SetIngredients(IngredientType.Main, recipeType);
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

    protected override bool IsAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.Ingredients;
        if(ingredients[IngredientType.Main] == RecipeType.None)
        {
            return true;
        }
        return false;
    }
}
