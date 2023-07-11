using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [SerializeField]
    List<GameObject> group = new List<GameObject>();
    [SerializeField]
    int count;

    public void Init(int cnt)
    {
        if(cnt>group.Count)
        {
            throw new System.Exception("머신의 최대수보다 초기화 값이 큼");
        }

        count = cnt; // 챕터 정보 받아오기
        for(int i=count;i<group.Count;i++)
        {
            group[i].SetActive(false);
        }
    }

    public List<Holder> GetEmptyList()
    {
        List<Holder> emptyList = new List<Holder>();
        for(int i=0;i<count;i++)
        {
            Holder holder = group[i].transform.GetChild(0).GetComponent<Holder>();
            if(!holder.working && holder.menu == null)
            {
                emptyList.Add(holder);
            }
        }
        return emptyList;
    }
}
