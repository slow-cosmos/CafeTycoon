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

    void MakeMenu(MenuType cup)
    {
        Holder holder = cupHolder.CanHold();
        if(holder != null)
        {
            GameObject menu = Instantiate(menuObject, holder.transform);
            switch(cup)
            {
                case MenuType.EspressoCup:
                    menu.AddComponent<EspressoCup>();
                    break;
                case MenuType.MugCup:
                    menu.AddComponent<MugCup>();
                    break;
                case MenuType.IceCup:
                    menu.AddComponent<IceCup>();
                    break;
            }
            holder.menu = menu;
        }
    }
}
