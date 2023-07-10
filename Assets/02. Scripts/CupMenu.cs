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
public abstract class CupMenu : MonoBehaviour
{
    public delegate void ChangeSprite(CupType cupType, Dictionary ingredients);
    public ChangeSprite changeSprite;

    [SerializeField]
    protected CupType cupType; // 컵 종류
    [SerializeField]
    protected int cost; // 가격
    public Dictionary ingredients = new Dictionary(); // 컵에 들어간 재료
    

    protected CupMenu() // 초기화
    {
        ingredients.Add(IngredientType.Main, RecipeType.None);
        ingredients.Add(IngredientType.Sub, RecipeType.None);
        ingredients.Add(IngredientType.Ice, RecipeType.None);
        ingredients.Add(IngredientType.Cream, RecipeType.None);

        cost = 0;
    }

    protected void InitCost()
    {
        cost = 0;
    }

    public void AddCost(int c)
    {
        cost += c;
    }

    protected void OnMouseDown() // 재료 오브젝트가 닿았을 때로 수정해야 함
    {
        RecipeType recipe = Picker.Instance.GetPick();
        if(recipe != RecipeType.None)
        {
            AddRecipe(recipe);
            Picker.Instance.SetPick(RecipeType.None);
        }
    }

    public abstract bool AddRecipe(RecipeType recipe);
}

public class EspressoCup : CupMenu
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

    public override bool AddRecipe(RecipeType recipe)
    {
        switch(recipe)
        {
            case RecipeType.Espresso:
                if(ingredients[IngredientType.Main] == RecipeType.None)
                {
                    ingredients[IngredientType.Main] = RecipeType.Espresso;
                    return true;
                }
                return false;                
                break;
            case RecipeType.Cream:
                if(ingredients[IngredientType.Main] != RecipeType.None)
                {
                    ingredients[IngredientType.Cream] = RecipeType.Cream;
                    return true;
                }
                return false;
                break;
            default:
                return false;
                break;
        }
        changeSprite(cupType, ingredients);
    }
}

public class MugCup : CupMenu
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

    public override bool AddRecipe(RecipeType recipe)
    {
        switch(recipe)
        {
            case RecipeType.Espresso:
                if(ingredients[IngredientType.Main] == RecipeType.None)
                {
                    ingredients[IngredientType.Main] = RecipeType.Espresso;
                    return true;
                }
                return false;
                break;
            case RecipeType.GreenTea:
                if(ingredients[IngredientType.Main] == RecipeType.None &&
                    (ingredients[IngredientType.Sub] == RecipeType.None ||
                    ingredients[IngredientType.Sub] == RecipeType.HotMilk))
                {
                    ingredients[IngredientType.Main] = RecipeType.GreenTea;
                    return true;
                }
                return false;
                break;
            case RecipeType.Water:
                if(ingredients[IngredientType.Main] != RecipeType.GreenTea &&
                    ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.Water;
                    return true;
                }
                return false;
                break;
            case RecipeType.HotMilk:
                if(ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.HotMilk;
                    return true;
                }
                return false;
                break;
            case RecipeType.Cream:
                if(ingredients[IngredientType.Main] == RecipeType.Espresso &&
                    ingredients[IngredientType.Sub] == RecipeType.Water)
                {
                    ingredients[IngredientType.Cream] = RecipeType.Cream;
                    return true;
                }
                return false;
                break;
            default:
                return false;
                break;
            
        }
        changeSprite(cupType, ingredients);
    }
}

public class IceCup : CupMenu
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

    public override bool AddRecipe(RecipeType recipe)
    {
        switch(recipe)
        {
            case RecipeType.Espresso:
                if(ingredients[IngredientType.Main] == RecipeType.None)
                {
                    ingredients[IngredientType.Main] = RecipeType.Espresso;
                    return true;
                }
                return false;
                break;
            case RecipeType.GreenTea:
                if(ingredients[IngredientType.Main] == RecipeType.None &&
                    (ingredients[IngredientType.Sub] == RecipeType.None ||
                    ingredients[IngredientType.Sub] == RecipeType.Milk))
                {
                    ingredients[IngredientType.Main] = RecipeType.GreenTea;
                    return true;
                }
                return false;
                break;
            case RecipeType.Water:
                if(ingredients[IngredientType.Main] != RecipeType.GreenTea &&
                    ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.Water;
                    return true;
                }
                return false;
                break;
            case RecipeType.Milk:
                if(ingredients[IngredientType.Sub] == RecipeType.None)
                {
                    ingredients[IngredientType.Sub] = RecipeType.Milk;
                    return true;
                }
                return false;
                break;
            case RecipeType.Ice:
                if(ingredients[IngredientType.Ice] == RecipeType.None)
                {
                    ingredients[IngredientType.Ice] = RecipeType.Ice;
                    return true;
                }
                return false;
                break;
            case RecipeType.Cream:
                if(ingredients[IngredientType.Main] == RecipeType.Espresso &&
                    ingredients[IngredientType.Sub] == RecipeType.Water &&
                    ingredients[IngredientType.Ice] == RecipeType.Ice)
                {
                    ingredients[IngredientType.Cream] = RecipeType.Cream;
                    return true;
                }
                return false;
                break;
            default:
                return false;
                break;
        }
        changeSprite(cupType, ingredients);
    }
}