using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinesManager : MonoBehaviour
{
    [SerializeField] private Machines coffeeMachines;
    [SerializeField] private Machines steamMachines;
    [SerializeField] private Machines ovens;
    [SerializeField] private Machines mixer;

    void Start()
    {
        coffeeMachines.Init(UpgradeManager.Instance.GetUpgradeInfo(0));
        steamMachines.Init(UpgradeManager.Instance.GetUpgradeInfo(1));
        ovens.Init(UpgradeManager.Instance.GetUpgradeInfo(2));
        mixer.Init(UpgradeManager.Instance.GetUpgradeInfo(3));
    }

}
