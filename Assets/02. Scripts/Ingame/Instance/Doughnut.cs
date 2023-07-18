using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doughnut : DoughMenu
{
    void Awake()
    {
        originPosition = transform.position;
        InitCost();
    }

    public override void InitCost()
    {
        cost = 5;
    }
}
