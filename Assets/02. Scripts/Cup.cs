using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CupType
{
    EspressoCup = 0,
    MugCup = 1,
    IceCup = 2,
}

public enum IngredientType
{
    Main, // 커피, 녹차
    Sub, // 물, 우유, 뜨거운 우유
    Ice,
    Cream,
}

[System.Serializable]
public class Dictionary : SerializableDictionary<IngredientType, RecipeType>{} // dictionary 인스펙터 표시

// 생성된 오브젝트
public abstract class Cup : MonoBehaviour
{
    public delegate void ChangeSprite(CupType cupType, Dictionary ingredients);
    public ChangeSprite changeSprite;

    [SerializeField]
    protected CupType cupType; // 컵 종류

    public Dictionary ingredients = new Dictionary(); // 컵에 들어간 재료

    public Cup() // 생성자 초기화
    {
        ingredients.Add(IngredientType.Main, RecipeType.None);
        ingredients.Add(IngredientType.Sub, RecipeType.None);
        ingredients.Add(IngredientType.Ice, RecipeType.None);
        ingredients.Add(IngredientType.Cream, RecipeType.None);
    }

    public void OnMouseDown() // 재료 오브젝트가 닿았을 때로 수정해야 함
    {
        RecipeType recipe = Picker.Instance.GetPick();
        if(recipe != RecipeType.None)
        {
            AddRecipe(recipe);
            Picker.Instance.SetPick(RecipeType.None);
        }
    }

    public abstract void AddRecipe(RecipeType recipe);
}

public class EspressoCup : Cup
{
    void Awake()
    {
        cupType = CupType.EspressoCup;
        Debug.Log("에소프레소잔 생성");
    }

    void Start()
    {
        changeSprite(cupType, ingredients);
    }

    public override void AddRecipe(RecipeType recipe)
    {
        switch(recipe)
        {
            case RecipeType.Espresso:
                ingredients[IngredientType.Main] = RecipeType.Espresso;
                break;
            case RecipeType.Cream:
                if(ingredients[IngredientType.Main] != RecipeType.None)
                {
                    ingredients[IngredientType.Cream] = RecipeType.Cream;
                }
                break;
            default:
                break;
        }
        changeSprite(cupType, ingredients);
    }
}

public class MugCup : Cup
{
    void Awake()
    {
        cupType = CupType.MugCup;
        Debug.Log("머그잔 생성");
    }

    void Start()
    {
        changeSprite(cupType, ingredients);
    }

    public override void AddRecipe(RecipeType recipe)
    {
        switch(recipe)
        {
            case RecipeType.Espresso:
                if(ingredients[IngredientType.Main] == RecipeType.None)
                {
                    ingredients[IngredientType.Main] = RecipeType.Espresso;
                }
                break;
            case RecipeType.GreenTea:
                if(ingredients[IngredientType.Main] == RecipeType.None &&
                    (ingredients[IngredientType.Sub] == RecipeType.None ||
                    ingredients[IngredientType.Sub] == RecipeType.HotMilk))
                {
                    ingredients[IngredientType.Main] = RecipeType.GreenTea;
                }
                break;
            case RecipeType.Water:
                if(ingredients[IngredientType.Main] != RecipeType.GreenTea &&
                    ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.Water;
                }
                break;
            case RecipeType.HotMilk:
                if(ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.HotMilk;
                }
                break;
            case RecipeType.Cream:
                if(ingredients[IngredientType.Main] == RecipeType.Espresso &&
                    ingredients[IngredientType.Sub] == RecipeType.Water)
                {
                    ingredients[IngredientType.Cream] = RecipeType.Cream;
                }
                break;
            default:
                break;
            
        }
        changeSprite(cupType, ingredients);
    }
}

public class IceCup : Cup
{
    void Awake()
    {
        cupType = CupType.IceCup;
        Debug.Log("얼음잔 생성");
    }

    void Start()
    {
        changeSprite(cupType, ingredients);
    }

    public override void AddRecipe(RecipeType recipe)
    {
        switch(recipe)
        {
            case RecipeType.Espresso:
                if(ingredients[IngredientType.Main] == RecipeType.None)
                {
                    ingredients[IngredientType.Main] = RecipeType.Espresso;
                }
                break;
            case RecipeType.GreenTea:
                if(ingredients[IngredientType.Main] == RecipeType.None &&
                    (ingredients[IngredientType.Sub] == RecipeType.None ||
                    ingredients[IngredientType.Sub] == RecipeType.Milk))
                {
                    ingredients[IngredientType.Main] = RecipeType.GreenTea;
                }
                break;
            case RecipeType.Water:
                if(ingredients[IngredientType.Main] != RecipeType.GreenTea &&
                    ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.Water;
                }
                break;
            case RecipeType.Milk:
                if(ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.Milk;
                }
                break;
            case RecipeType.Ice:
                ingredients[IngredientType.Ice] = RecipeType.Ice;
                break;
            case RecipeType.Cream:
                if(ingredients[IngredientType.Main] == RecipeType.Espresso &&
                    ingredients[IngredientType.Sub] == RecipeType.Water &&
                    ingredients[IngredientType.Ice] == RecipeType.Ice)
                {
                    ingredients[IngredientType.Cream] = RecipeType.Cream;
                }
                break;
            default:
                break;
        }
        changeSprite(cupType, ingredients);
    }
}