using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OrderType
{
    Espresso,
    EspressoConPanna,
    Americano,
    CaffeLatte,
    CaffeVienna,
    GreenTeaLatte,
    IceAmericano,
    IceCaffeLatte,
    IceCaffeVienna,
    IceGreenTeaLatte,
    Juice,
    Doughnut,
    Cookie
}

public class Order : MonoBehaviour
{
    [SerializeField]
    RectTransform rectTransform;
    [SerializeField]
    Image image;

    public List<Sprite> sprites = new List<Sprite>();
    public OrderType orderType;

    void Start()
    {
        image.sprite = sprites[(int)orderType];
        rectTransform.sizeDelta = new Vector3(sprites[(int)orderType].bounds.size.x*90, sprites[(int)orderType].bounds.size.y*90);
    }
}
