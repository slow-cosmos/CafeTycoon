using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGenerator : MonoBehaviour
{   
    public HolderManager cupHolder;

    public GameObject menuObject;  // 메뉴 프리팹

    [SerializeField]
    private List<Counter> cups; // 카운터의 메뉴

    void Awake()
    {
        foreach(var cup in cups) // 메뉴 클릭 이벤트 추가
        {
            cup.menuGenerate += MakeMenu;
        }
    }

    void MakeMenu(CupType cup)
    {
        Holder holder = cupHolder.CanHold();
        if(holder != null)
        {
            GameObject menu = Instantiate(menuObject, holder.transform);
            switch(cup)
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
            menu.AddComponent<BoxCollider>();
            holder.menu = menu;
        }
    }
}
