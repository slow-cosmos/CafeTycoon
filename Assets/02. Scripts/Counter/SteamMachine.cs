using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamMachine : MonoBehaviour, IMakeMenu
{
    public GameObject hotMilkObject;
    [SerializeField]
    Holder holder;

    [SerializeField]
    bool isWorking = false;

    [SerializeField]
    float timer;

    void Awake()
    {
        timer = 3.0f; // 임시 타이머
    }

    public void MakeMenu()
    {
        if(holder.menu == null && isWorking == false)
        {
            StartCoroutine(HotMilkGenerate());
        }
    }

    IEnumerator HotMilkGenerate()
    {
        isWorking = true;

        yield return new WaitForSeconds(timer);
        GameObject menu = Instantiate(hotMilkObject, holder.transform);
        
        holder.menu = menu;
        isWorking = false;
    }
}
