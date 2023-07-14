using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    [SerializeField]
    Group coffeeMachines;
    [SerializeField]
    Group steamMachines;
    [SerializeField]
    Group ovens;
    [SerializeField]
    Group mixer;

    void Awake()
    {
        try
        {
            //챕터 정보에서 받아오기
            coffeeMachines.Init(2);
            steamMachines.Init(1);
            ovens.Init(1);
            mixer.Init(2);
        }
        catch (System.Exception exception)
        {
            Debug.Log(exception.Message);
        }
    }

}
