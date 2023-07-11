using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IMakeMenu
{
    public GameObject dough;

    [SerializeField]
    Holder holder;

    [SerializeField]
    float timer;

    void Awake()
    {
        timer = 3.0f; // 임시 타이머
    }

    public void MakeMenu()
    {
        if(holder.menu == null && holder.working == false)
        {
            StartCoroutine(Bake());
        }
    }

    IEnumerator Bake()
    {
        holder.working = true;

        yield return new WaitForSeconds(timer);
        Debug.Log("다 구워짐!");

        //클릭해야지
        GameObject menu = Instantiate(dough, holder.transform);
        
        holder.menu = menu;
        holder.working = false;
    }
}