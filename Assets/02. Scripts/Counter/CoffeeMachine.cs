using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour, IMakeMenu
{
    public GameObject coffeeObject;

    [SerializeField]
    Group group;

    [SerializeField]
    float timer;

    void Awake()
    {
        timer = 3.0f; // 임시 타이머
    }
    
    void OnMouseDown()
    {
        MakeMenu();
    }

    public void MakeMenu()
    {
        StartCoroutine(CoffeeGenerate());
    }

    IEnumerator CoffeeGenerate()
    {
        List<Holder> emptyList = group.GetEmptyList();
        if(emptyList.Count != 0)
        {
            foreach(var holder in emptyList)
            {
                holder.working = true;
            }

            yield return new WaitForSeconds(timer);

            foreach(var holder in emptyList)
            {
                GameObject menu = Instantiate(coffeeObject, holder.transform);
                holder.menu = menu;
                holder.working = false;
            }
        }
    }
}
