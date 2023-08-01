using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotMilk : Recipe
{
    protected override void Awake()
    {
        base.Awake();
        InitCost();
    }

    public override void InitCost()
    {
        cost = UpgradeManager.Instance.GetUpgrade("Milk:Cost");
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

    protected override bool IsAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.Ingredients;
        if(cup.cupType == CupType.MugCup &&
            ingredients[IngredientType.Sub] == RecipeType.None)
        {
            return true;
        }
        return false;
    }
}
