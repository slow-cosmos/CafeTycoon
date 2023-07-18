using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Recipe
{
    BoxCollider collider;

    protected override void Awake()
    {
        base.Awake();
        InitCost();
        collider = GetComponent<BoxCollider>();
    }

    public override void InitCost()
    {
        // 업그레이드 정보에 맞춰 가격 초기화
        cost = 5;
    }

    public void OnMouseDrag()
    {
        base.OnMouseDrag();
        ChangeColliderSize(1.05f, 0.95f);
    }

    public override void OnMouseUp()
    {
        if(trigger != null && trigger.CompareTag("Cup")) 
        {
            CupMenu cup = trigger.GetComponent<CupMenu>();
            if(IsAddable(cup)) // 컵에 추가할 수 있으면
            {
                cup.SetIngredients(IngredientType.Ice, recipeType);
                cup.AddCost(cost);
            }
        }
        renderer.sprite = sprites[0];
        transform.position = originPosition;
        ChangeColliderSize(2.45f, 2.26f);
    }

    protected override bool IsAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.Ingredients;
        if(cup.cupType == CupType.IceCup &&
            ingredients[IngredientType.Ice] == RecipeType.None)
        {
            return true;
        }
        return false;
    }

    private void ChangeColliderSize(float x, float y)
    {
        collider.size = new Vector3(x, y, 0);
    }
}
