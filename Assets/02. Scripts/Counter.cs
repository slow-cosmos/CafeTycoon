using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카운터에서 클릭할 오브젝트 (머신, 컵 등)
public class Counter : MonoBehaviour
{
    public delegate void MenuGenerate(MenuType menu);
    public MenuGenerate menuGenerate;

    public MenuType menuType;

    public void OnMouseDown()
    {
        menuGenerate(menuType);
    }
}

