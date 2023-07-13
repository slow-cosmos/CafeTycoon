using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 머신, 홀더 등을 관리
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

    public List<GameObject> GetObjects()
    {
        return group;
    }

    public int GetObjectsCount()
    {
        return count;
    }
}
