using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamMachine : MonoBehaviour, IMakeMenu
{
    public GameObject hotMilkObject;

    [SerializeField] private Animator animator;

    [SerializeField] private Holder holder;
    [SerializeField] private Collider col;

    [SerializeField] private bool isWorking = false;
    [SerializeField] private float timer;

    private void Awake()
    {
        timer = 7.0f; // 임시 타이머
    }

    public void MakeMenu()
    {
        if(holder.Object == null && isWorking == false)
        {
            SoundManager.Instance.PlayEffect("steammachine");
            StartCoroutine(HotMilkGenerate());
        }
    }

    private IEnumerator HotMilkGenerate()
    {
        isWorking = true;

        animator.SetInteger("State", 1);

        yield return new WaitForSeconds(timer);

        GameObject menu = Instantiate(hotMilkObject, holder.transform);
        
        holder.Object = menu;
        isWorking = false;
        col.enabled = false;

        while(holder.Object != null)
        {
            yield return null;
        }

        col.enabled = true;
        animator.SetInteger("State", 0);
    }
}
