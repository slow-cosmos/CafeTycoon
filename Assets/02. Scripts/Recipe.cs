using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RecipeType
{
    None,
    Espresso,
    GreenTea,
    Water,
    Milk,
    HotMilk,
    Ice,
    Cream
}

public class Recipe : MonoBehaviour
{
    public RecipeType recipeType;

    void OnMouseDown()
    {
        Picker.Instance.SetPick(this);
    }
}
