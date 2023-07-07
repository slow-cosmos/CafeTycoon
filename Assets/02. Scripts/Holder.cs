using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public GameObject menu; // 홀더가 잡고있는 메뉴
    public bool working; // 제조 중일 때 확인하기 위해

    void Awake()
    {
        menu = null;
        working = false;
    }
}
