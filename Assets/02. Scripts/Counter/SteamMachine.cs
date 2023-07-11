using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamMachine : MonoBehaviour, IMakeMenu
{
    public GameObject hotMilkObject;
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
            StartCoroutine(HotMilkGenerate());
        }
    }

    IEnumerator HotMilkGenerate()
    {
        holder.working = true;

        yield return new WaitForSeconds(timer);
        GameObject menu = Instantiate(hotMilkObject, holder.transform);
        
        holder.menu = menu;
        holder.working = false;
    }
}
