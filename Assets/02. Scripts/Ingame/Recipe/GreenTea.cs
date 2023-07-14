using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTea : Recipe
{
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        originPosition = transform.position;

        cost = 5; // 가격 불러오는 걸로 갱신
    }

    public override void OnMouseUp()
    {
        if(trigger != null && trigger.CompareTag("Cup")) 
        {
            CupMenu cup = trigger.GetComponent<CupMenu>();
            if(IsAddable(cup)) // 컵에 추가할 수 있으면
            {
                cup.SetIngredients(IngredientType.Main, recipeType);
                cup.AddCost(cost);
            }
        }
        renderer.sprite = sprites[0];
        transform.position = originPosition;
    }

    protected override bool IsAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.GetIngredients();
        if(cup.cupType == CupType.MugCup) // 머그컵
        {
            if(ingredients[IngredientType.Main] == RecipeType.None &&
                (ingredients[IngredientType.Sub] == RecipeType.None ||
                ingredients[IngredientType.Sub] == RecipeType.HotMilk))
            {
                return true;
            }
        }
        else if(cup.cupType == CupType.IceCup) // 얼음컵
        {
            if(ingredients[IngredientType.Main] == RecipeType.None &&
                (ingredients[IngredientType.Sub] == RecipeType.None ||
                ingredients[IngredientType.Sub] == RecipeType.Milk))
            {
                return true;
            }
        }
        return false;
    }
}
