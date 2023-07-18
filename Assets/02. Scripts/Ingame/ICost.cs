using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICostInit
{
    void InitCost();
}

public interface ICostAdd
{
    void AddCost(int cost);
}