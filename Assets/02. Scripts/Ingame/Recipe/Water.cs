using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Recipe
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
        if(trigger != null && trigger.CompareTag("Cup")) 
        {
            CupMenu cup = trigger.GetComponent<CupMenu>();
            if(IsAddable(cup)) // 컵에 추가할 수 있으면
            {
                cup.SetIngredients(IngredientType.Sub, recipeType);
                cup.AddCost(cost);
            }
        }
        renderer.sprite = sprites[0];
        transform.position = originPosition;
    }

    protected override bool IsAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.Ingredients;
        if(cup.cupType != CupType.EspressoCup)
        {
            if(ingredients[IngredientType.Sub] == RecipeType.None &&
                ingredients[IngredientType.Main] != RecipeType.GreenTea)
            {
                return true;
            }
        }
        return false;
    }
}