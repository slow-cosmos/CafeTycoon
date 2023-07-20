using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : DoughMenu
{
    private void Awake()
    {
        originPosition = transform.position;

        InitCost();

        menu = OrderType.Cookie;
    }

    public override void InitCost()
    {
        cost = 5;
    }
}
