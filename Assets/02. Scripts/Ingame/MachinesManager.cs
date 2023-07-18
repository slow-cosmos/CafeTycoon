using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinesManager : MonoBehaviour
{
    [SerializeField]
    Machines coffeeMachines;
    [SerializeField]
    Machines steamMachines;
    [SerializeField]
    Machines ovens;
    [SerializeField]
    Machines mixer;

    void Awake()
    {
        //챕터 정보에서 받아오기
        coffeeMachines.Init(2);
        steamMachines.Init(1);
        ovens.Init(1);
        mixer.Init(2);
    }

}
