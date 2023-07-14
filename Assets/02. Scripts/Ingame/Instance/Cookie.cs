using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : DoughMenu
{
    void Awake()
    {
        originPosition = transform.position;
        cost = 5; // 가격 불러오는 걸로 갱신
    }
}
