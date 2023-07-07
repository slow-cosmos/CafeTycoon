using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public List<Holder> holders = new List<Holder>();
    public int holderCount;

    void Awake()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        HolderInit();
    }

    void HolderInit()
    {
        holderCount = 2; // 업그레이드 정보로 바꾸기
        spriteRenderer.sprite = sprites[holderCount-1];
    }

    public Holder CanHold()
    {
        for(int i=0;i<holderCount;i++)
        {
            if(holders[i].menu == null)
            {
                return holders[i]; // 자리 있으면 홀더 오브젝트 반환
            }
        }
        Debug.Log("자리 없음!");
        return null; // 없으면 null 반환
    }

    public List<Holder> CanHoldCoffee()
    {
        List<Holder> emptyHolders = new List<Holder>();
        for(int i=0;i<holderCount;i++)
        {
            if(!holders[i].working && holders[i].menu == null)
            {
                emptyHolders.Add(holders[i]);
            }
        }
        return emptyHolders;
    }
}
