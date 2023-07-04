using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuType
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
public class Dictionary : SerializableDictionary<IngredientType, RecipeType>{}

// 생성된 오브젝트
public abstract class Menu : MonoBehaviour
{
    public delegate void SpriteChange(int index);
    public SpriteChange spriteChange;

    [SerializeField]
    protected MenuType menu;

    public Dictionary ingredients = new Dictionary();

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

public class EspressoCup : Menu
{
    void Awake()
    {
        menu = MenuType.EspressoCup;
        Debug.Log("에소프레소잔 생성");

        ingredients.Add(IngredientType.Main, RecipeType.None);
        ingredients.Add(IngredientType.Cream, RecipeType.None);
    }

    void Start()
    {
        spriteChange((int)MenuType.EspressoCup);
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
    }
}

public class MugCup : Menu
{
    void Awake()
    {
        menu = MenuType.MugCup;
        Debug.Log("머그잔 생성");

        ingredients.Add(IngredientType.Main, RecipeType.None);
        ingredients.Add(IngredientType.Sub, RecipeType.None);
        ingredients.Add(IngredientType.Cream, RecipeType.None);
    }

    void Start()
    {
        spriteChange((int)MenuType.MugCup);
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
    }
}

public class IceCup : Menu
{
    void Awake()
    {
        menu = MenuType.IceCup;
        Debug.Log("얼음잔 생성");
    }

    void Start()
    {
        spriteChange((int)MenuType.IceCup);
    }

    public override void AddRecipe(RecipeType recipe)
    {
        
    }
}