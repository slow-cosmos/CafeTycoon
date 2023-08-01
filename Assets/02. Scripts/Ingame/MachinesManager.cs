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
        coffeeMachines.Init(UpgradeManager.Instance.GetUpgrade("EspressoMachine:Count"));
        steamMachines.Init(UpgradeManager.Instance.GetUpgrade("SteamMachine:Count"));
        ovens.Init(UpgradeManager.Instance.GetUpgrade("Oven:Count"));
        mixer.Init(UpgradeManager.Instance.GetUpgrade("Mixer:Count"));
    }

}
