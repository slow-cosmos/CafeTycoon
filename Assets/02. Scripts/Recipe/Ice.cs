using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Recipe
{
    BoxCollider collider;

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
        
        renderer = GetComponent<SpriteRenderer>();
        originPosition = transform.position;

        cost = 5; // 가격 불러오는 걸로 갱신
    }

    public void OnMouseDrag()
    {
        renderer.sprite = sprites[1];
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
        ChangeColliderSize(1.05f, 0.95f);
    }

    public override void OnMouseUp()
    {
        if(trigger != null && trigger.CompareTag("Cup")) 
        {
            CupMenu cup = trigger.GetComponent<CupMenu>();
            if(isAddable(cup)) // 컵에 추가할 수 있으면
            {
                cup.SetIngredients(IngredientType.Ice, recipeType);
                cup.AddCost(cost);
            }
        }
        renderer.sprite = sprites[0];
        transform.position = originPosition;
        ChangeColliderSize(2.45f, 2.26f);
    }

    protected override bool isAddable(CupMenu cup)
    {
        Dictionary ingredients = cup.GetIngredients();
        if(cup.cupType == CupType.IceCup &&
            ingredients[IngredientType.Ice] == RecipeType.None)
        {
            return true;
        }
        return false;
    }

    void ChangeColliderSize(float x, float y)
    {
        collider.size = new Vector3(x, y, 0);
    }
}
