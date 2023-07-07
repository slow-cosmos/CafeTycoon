using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGenerator : MonoBehaviour
{   
    [SerializeField]
    HolderManager cupHolder;
    [SerializeField]
    HolderManager coffeeHolder;

    public GameObject cupObject;
    public GameObject coffeeObject;

    public void MenuGenerate(CounterType counter)
    {
        switch(counter)
        {
            case CounterType.CoffeeMachine:
                StartCoroutine(CoffeeGenerate(counter));
                break;
            default:
                CupGenerate(counter);
                break;
        }
    }

    void CupGenerate(CounterType cup)
    {
        Holder holder = cupHolder.CanHold();
        if(holder != null)
        {
            GameObject menu = Instantiate(cupObject, holder.transform);
            switch(cup) // 컵 종류에 따라 다르게 생성 (홀더는 같음)
            {
                case CounterType.EspressoCup:
                    menu.AddComponent<EspressoCup>();
                    break;
                case CounterType.MugCup:
                    menu.AddComponent<MugCup>();
                    break;
                case CounterType.IceCup:
                    menu.AddComponent<IceCup>();
                    break;
            }
            menu.AddComponent<BoxCollider>();
            holder.menu = menu;
        }
    }

    IEnumerator CoffeeGenerate(CounterType coffee)
    {
        List<Holder> emptyHolders = coffeeHolder.CanHoldCoffee();
        if(emptyHolders.Count != 0)
        {
            foreach(var holder in emptyHolders)
            {
                holder.working = true;
            }

            yield return new WaitForSeconds(3.0f);

            foreach(var holder in emptyHolders)
            {
                GameObject menu = Instantiate(coffeeObject, holder.transform);
                holder.menu = menu;
                holder.working = false;
            }
        }
    }
}
