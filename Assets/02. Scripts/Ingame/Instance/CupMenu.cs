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
            // add : 컵이 완성됐으면
            if(trigger.CompareTag("Customer"))
            {
                Sprite sprite = GetComponent<SpriteRenderer>().sprite;
                Customer customer = trigger.GetComponent<Customer>();
                if(customer.MatchMenu(sprite))
                {
                    customer.AddCost(cost);
                    Destroy(gameObject);
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

    void Start()
    {
        changeSprite(cupType, ingredients);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
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

    void Start()
    {
        changeSprite(cupType, ingredients);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
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

    void Start()
    {
        changeSprite(cupType, ingredients);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}