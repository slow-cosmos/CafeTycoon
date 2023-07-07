using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CounterType
{
    EspressoCup, // 터치
    MugCup,
    IceCup,
    CoffeeMachine,
    Mixer, 
    SteamMachine, // 드래그
    Oven,
}

// 카운터에서 클릭할 오브젝트
public class Counter : MonoBehaviour
{
    MenuGenerator menuGenerator;

    public CounterType counter;

    void Awake()
    {
        menuGenerator = GameObject.Find("MenuGenerator").GetComponent<MenuGenerator>();
        // 나중에 대리자로 교체
    }

    void OnMouseDown()
    {
        menuGenerator.MenuGenerate(counter);
    }
}