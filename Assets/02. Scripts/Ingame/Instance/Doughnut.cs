using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doughnut : DoughMenu
{
    private void Awake()
    {
        originPosition = transform.position;

        InitCost();

        menu = OrderType.Doughnut;
    }

    public override void InitCost()
    {
        cost = 5;
    }
}
