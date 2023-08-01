using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cream : Recipe
{
    protected override void Awake()
    {
        base.Awake();
        InitCost();
    }

    public override void InitCost()
    {
        cost = UpgradeManager.Instance.GetUpgrade("Cream:Cost");
    }

    public override void OnMouseUp()
    {
        if(trigger != null && trigger.CompareTag("Cup")) 
        {
            CupMenu cup = trigger.GetComponent<CupMenu>();
            if(IsAddable(cup)) // 컵에 추가할 수 있으면
            {
                cup.SetIngredients(IngredientType.Cream, recipeType);
                cup.AddCost(cost);
            }
        }
        renderer.sprite = sprites[0];
        transform.position = originPosition;
    }

    protected override bool IsAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.Ingredients;
        if(cup.cupType == CupType.EspressoCup) // 에스프레소컵
        {
            if(ingredients[IngredientType.Cream] == RecipeType.None &&
                ingredients[IngredientType.Main] == RecipeType.Espresso)
            {
                return true;
            }
        }
        else if(cup.cupType == CupType.MugCup) // 머그컵
        {
            if(ingredients[IngredientType.Cream] == RecipeType.None &&
                ingredients[IngredientType.Main] == RecipeType.Espresso &&
                ingredients[IngredientType.Sub] == RecipeType.Water)
            {
                return true;
            }
        }
        else if(cup.cupType == CupType.IceCup) // 얼음컵
        {
            if(ingredients[IngredientType.Cream] == RecipeType.None &&
                ingredients[IngredientType.Main] == RecipeType.Espresso &&
                ingredients[IngredientType.Sub] == RecipeType.Water &&
                ingredients[IngredientType.Ice] == RecipeType.Ice)
            {
                return true;
            }
        }
        return false;
    }
}
