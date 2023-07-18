using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 머신 숫자를 관리
public class Machines : MonoBehaviour
{
    [SerializeField] private List<GameObject> machinesList = new List<GameObject>();
    public List<GameObject> MachinesList
    {
        get
        {
            return machinesList;
        }
    }

    [SerializeField] private int machinesCount;
    public int MachineCount
    {
        get
        {
            return machinesCount;
        }
    }

    public void Init(int cnt)
    {
        machinesCount = cnt; // 챕터 정보 받아오기
        for(int i=machinesCount;i<machinesList.Count;i++)
        {
            machinesList[i].SetActive(false);
        }
    }
}
