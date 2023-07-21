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
public abstract class CupMenu : MonoBehaviour, ICostInit, ICostAdd
{
    public delegate void ChangeSprite(CupType cupType, Dictionary ingredients);
    public ChangeSprite changeSprite;

    protected Vector3 originPosition;

    [SerializeField] protected GameObject trigger; // 트리거 오브젝트

    public CupType cupType; // 컵 종류
    public int cost; // 가격
    public bool isCompleted; // 컵이 완성 됐는지
    public OrderType menu; // 완성된 메뉴 타입

    [SerializeField] protected Dictionary ingredients = new Dictionary(); // 컵에 들어간 재료
    public Dictionary Ingredients
    {
        get
        {
            return ingredients;
        }
    }
    
    protected virtual void Awake() // 초기화
    {
        ingredients.Add(IngredientType.Main, RecipeType.None);
        ingredients.Add(IngredientType.Sub, RecipeType.None);
        ingredients.Add(IngredientType.Ice, RecipeType.None);
        ingredients.Add(IngredientType.Cream, RecipeType.None);

        InitCost();

        isCompleted = false;
        menu = OrderType.None;

        changeSprite += GetComponent<SpriteChanger>().ChangeSprite;
    }

    public void InitCost()
    {
        cost = 0;
    }

    public void AddCost(int c)
    {
        cost += c;
    }

    public void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
    }

    public void OnMouseUp()
    {
        if(trigger != null)
        {
            if(trigger.CompareTag("Customer"))
            {
                if(isCompleted)
                {
                    Customer customer = trigger.GetComponent<Customer>();
                    if(customer.MatchMenu(menu, cost))
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Debug.Log("완성이 되어야 줄 수 있음");
                }
                
            }
            if(trigger.CompareTag("Trash"))
            {
                Destroy(gameObject);
            }
        }
        transform.position = originPosition;
    }

    protected void OnTriggerStay(Collider col)
    {
        trigger = col.gameObject;
    }

    protected void OnTriggerExit(Collider col)
    {
        trigger = null;
    }

    public void SetIngredients(IngredientType ingredient, RecipeType recipe)
    {
        ingredients[ingredient] = recipe;
        changeSprite(cupType, ingredients);
    }
}

public class EspressoCup : CupMenu
{
    protected override void Awake()
    {
        base.Awake();

        cupType = CupType.EspressoCup;
        Debug.Log("에소프레소잔 생성");

        originPosition = transform.position;
    }

    private void Start()
    {
        changeSprite(cupType, ingredients);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void Update()
    {
        if(!isCompleted)
        {
            if(ingredients[IngredientType.Main] != RecipeType.None)
            {
                isCompleted = true;
            }
        }
        else
        {
            if(ingredients[IngredientType.Main] == RecipeType.Espresso)
            {
                if(ingredients[IngredientType.Cream] == RecipeType.None)
                {
                    //Debug.Log("에스프레소");
                    menu = OrderType.Espresso;
                }
                else if(ingredients[IngredientType.Cream] == RecipeType.Cream)
                {
                    //Debug.Log("콘파냐");
                    menu = OrderType.EspressoConPanna;
                }
            }
        }
    }
}

public class MugCup : CupMenu
{
    protected override void Awake()
    {
        base.Awake();
        
        cupType = CupType.MugCup;
        Debug.Log("머그잔 생성");

        originPosition = transform.position;
    }

    private void Start()
    {
        changeSprite(cupType, ingredients);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void Update()
    {
        if(!isCompleted)
        {
            if(ingredients[IngredientType.Main] != RecipeType.None &&
                ingredients[IngredientType.Sub] != RecipeType.None)
            {
                isCompleted = true;
            }
        }
        else
        {
            if(ingredients[IngredientType.Main] == RecipeType.Espresso)
            {
                if(ingredients[IngredientType.Sub] == RecipeType.Water)
                {
                    if(ingredients[IngredientType.Cream] == RecipeType.None)
                    {
                        //Debug.Log("아메리카노");
                        menu = OrderType.Americano;
                    }
                    else
                    {
                        //Debug.Log("카페비엔나");
                        menu = OrderType.CaffeVienna;
                    }
                }
                else if(ingredients[IngredientType.Sub] == RecipeType.HotMilk)
                {
                    //Debug.Log("카페라떼");
                    menu = OrderType.CaffeLatte;
                }
            }
            else if(ingredients[IngredientType.Main] == RecipeType.GreenTea)
            {
                if(ingredients[IngredientType.Sub] == RecipeType.HotMilk)
                {
                    //Debug.Log("그린티라떼");
                    menu = OrderType.GreenTeaLatte;
                }
            }
        }
    }
}

public class IceCup : CupMenu
{
    protected override void Awake()
    {
        base.Awake();
        
        cupType = CupType.IceCup;
        Debug.Log("얼음잔 생성");

        originPosition = transform.position;
    }

    private void Start()
    {
        changeSprite(cupType, ingredients);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    private void Update()
    {
        if(!isCompleted)
        {
            if(ingredients[IngredientType.Main] != RecipeType.None &&
                ingredients[IngredientType.Sub] != RecipeType.None &&
                ingredients[IngredientType.Ice] != RecipeType.None)
            {
                isCompleted = true;
            }
        }
        else
        {
            if(ingredients[IngredientType.Main] == RecipeType.Espresso)
            {
                if(ingredients[IngredientType.Sub] == RecipeType.Water)
                {
                    if(ingredients[IngredientType.Cream] == RecipeType.None)
                    {
                        //Debug.Log("아이스 아메리카노");
                        menu = OrderType.IceAmericano;
                    }
                    else
                    {
                        //Debug.Log("아이스 카페비엔나");
                        menu = OrderType.IceCaffeVienna;
                    }
                }
                else if(ingredients[IngredientType.Sub] == RecipeType.Milk)
                {
                    //Debug.Log("아이스 카페라떼");
                    menu = OrderType.IceCaffeLatte;
                }
            }
            else if(ingredients[IngredientType.Main] == RecipeType.GreenTea)
            {
                if(ingredients[IngredientType.Sub] == RecipeType.Milk)
                {
                    //Debug.Log("아이스 그린티라떼");
                    menu = OrderType.IceGreenTeaLatte;
                }
            }
        }
    }
}