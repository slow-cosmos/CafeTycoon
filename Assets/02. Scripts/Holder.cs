using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public GameObject menu = null; // 홀더가 잡고있는 메뉴

    void Awake()
    {
        menu = null;
    }
}
