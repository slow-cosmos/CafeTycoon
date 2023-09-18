using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#region 5차원 배열 인스펙터 표시
[Serializable]
public class _2DArray
{
    [Header("Cream")]
    public Sprite[] sprites = new Sprite[2];
}

[Serializable]
public class _3DArray
{
    [Header("Ice")]
    public _2DArray[] sprites = new _2DArray[2];
}

[Serializable]
public class _4DArray
{
    [Header("Sub")]
    public _3DArray[] sprites = new _3DArray[4];
}

[Serializable]
public class _5DArray
{
    [Header("Main")]
    public _4DArray[] sprites = new _4DArray[3];
}
#endregion

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Cup")]
    public _5DArray[] sprites = new _5DArray[3];

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(CupType cupType, Dictionary ingredients)
    {
        int mainIdx = (int)ingredients[IngredientType.Main];
        int subIdx = ingredients[IngredientType.Sub] == RecipeType.None ? 0 : (int)ingredients[IngredientType.Sub] % 3 + 1;
        int iceIdx = (int)ingredients[IngredientType.Ice] % 5;
        int creamIdx = (int)ingredients[IngredientType.Cream] % 6;
        spriteRenderer.sprite = sprites[(int)cupType].sprites[mainIdx].sprites[subIdx].sprites[iceIdx].sprites[creamIdx];
        spriteRenderer.flipX = true;
    }

    public void InitSprite(CupType cupType)
    {
        spriteRenderer.sprite = sprites[(int)cupType].sprites[0].sprites[0].sprites[0].sprites[0];
    }
}
