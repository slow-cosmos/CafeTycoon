using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RecipeType
{
    None = 0,
    Espresso = 1,
    GreenTea = 2,
    Water = 3,
    Milk = 4,
    HotMilk = 5,
    Ice = 6,
    Cream = 7
}

public class Recipe : MonoBehaviour
{
    public RecipeType recipeType;

    void OnMouseDown()
    {
        Picker.Instance.SetPick(recipeType);
    }
}
