using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카운터에서 클릭할 오브젝트 (머신, 컵 등)
public class Counter : MonoBehaviour
{
    public delegate void MenuGenerate(CupType menu);
    public MenuGenerate menuGenerate;

    public CupType cupType;

    void OnMouseDown()
    {
        menuGenerate(cupType);
    }
}

