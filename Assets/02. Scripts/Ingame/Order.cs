using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    Espresso,
    EspressoConPanna,
}

public class Order : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public OrderType orderType;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)orderType];
    }
}
