using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICostInit, ICostAdd
{
    [SerializeField] private int cost;
    public int Cost
    {
        get
        {
            return cost;
        }
    }

    private void Awake()
    {
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
}
