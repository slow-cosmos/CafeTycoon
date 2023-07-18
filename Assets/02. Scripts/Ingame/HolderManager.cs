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
        Init();
    }

    void Init()
    {
        holderCount = 2; // 업그레이드 정보로 바꾸기
        spriteRenderer.sprite = sprites[holderCount-1];
        for(int i=holderCount;i<holders.Count;i++)
        {
            holders[i].gameObject.SetActive(false);
        }
    }

    public Holder CanHold()
    {
        for(int i=0;i<holderCount;i++)
        {
            if(holders[i].Object == null)
            {
                return holders[i]; // 자리 있으면 홀더 오브젝트 반환
            }
        }
        Debug.Log("자리 없음!");
        return null; // 없으면 null 반환
    }
}
