using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    float timer;
    public float timeSpeed;

    // 코인
    // 코인 퍼센트

    [SerializeField]
    List<Sprite> menuList = new List<Sprite>();

    bool MatchMenu(Sprite menu)
    {
        return true;
    }

}
