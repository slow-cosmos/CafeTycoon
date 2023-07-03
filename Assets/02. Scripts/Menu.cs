using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuType
{
    EspressoCup = 0,
    MugCup = 1,
    IceCup = 2,
}

// 생성된 오브젝트
public class Menu : MonoBehaviour
{
    public delegate void SpriteChange(int index);
    public SpriteChange spriteChange;

    [SerializeField]
    protected MenuType menu;
}

public class EspressoCup : Menu
{
    void Awake()
    {
        menu = MenuType.EspressoCup;
        Debug.Log("에소프레소잔 생성");
    }

    void Start()
    {
        spriteChange((int)MenuType.EspressoCup);
    }
}

public class MugCup : Menu
{
    void Awake()
    {
        menu = MenuType.MugCup;
        Debug.Log("머그잔 생성");
    }

    void Start()
    {
        spriteChange((int)MenuType.MugCup);
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
}