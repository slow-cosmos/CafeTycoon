using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour, IMakeMenu
{
    public GameObject cupObject;

    [SerializeField] private HolderManager cupHolder;

    [SerializeField] private CupType cupType;

    void OnMouseDown()
    {
        MakeMenu();
    }

    public void MakeMenu()
    {
        Holder holder = cupHolder.CanHold();
        if(holder != null)
        {
            GameObject menu = Instantiate(cupObject, holder.transform);
            switch(cupType) // 컵 종류에 따라 다르게 생성 (홀더는 같음)
            {
                case CupType.EspressoCup:
                    menu.AddComponent<EspressoCup>();
                    break;
                case CupType.MugCup:
                    menu.AddComponent<MugCup>();
                    break;
                case CupType.IceCup:
                    menu.AddComponent<IceCup>();
                    break;
            }
            
            holder.Object = menu;
        }
    }
}
