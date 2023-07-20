using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamMachine : MonoBehaviour, IMakeMenu
{
    public GameObject hotMilkObject;

    [SerializeField] private Holder holder;

    [SerializeField] private bool isWorking = false;
    [SerializeField] private float timer;

    private void Awake()
    {
        timer = 3.0f; // 임시 타이머
    }

    public void MakeMenu()
    {
        if(holder.Object == null && isWorking == false)
        {
            StartCoroutine(HotMilkGenerate());
        }
    }

    IEnumerator HotMilkGenerate()
    {
        isWorking = true;

        yield return new WaitForSeconds(timer);
        GameObject menu = Instantiate(hotMilkObject, holder.transform);
        
        holder.Object = menu;
        isWorking = false;
    }
}
