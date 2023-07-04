using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picker : MonoBehaviour
{
    private static Picker instance = null;
    public static Picker Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public RecipeType pickRecipeType;

    void Awake()
    {
        if(null == instance)
        {
            instance = this;
        }

        pickRecipeType = RecipeType.None;
    }

    public void SetPick(Recipe recipe)
    {
        pickRecipeType = recipe.recipeType;
    }

    public void SetPick(RecipeType recipe)
    {
        pickRecipeType = recipe;
    }

    public RecipeType GetPick()
    {
        return pickRecipeType;
    }
}
