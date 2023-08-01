using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum UpgradeObject
{
    EspressoMachine,
    SteamMachine,
    Oven,
    Mixer,
    Tray,
    Espresso,
    Water,
    Milk,
    Ice,
    Cream,
    GreenTea,
    Cookie,
    Doughnut,
    Juice
}

public enum UpgradeType
{
    Count,
    Time,
    Cost
}

[Serializable]
public struct UpgradeInfo
{
    public UpgradeObject upgradeObject;
    public UpgradeType upgradeType;

    public string name;
    public Sprite sprite;
    public List<int> upgrade; // 업그레이드 정보
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public List<UpgradeInfo> UpgradeList => upgradeList;

    [SerializeField] private List<UpgradeInfo> upgradeList = new List<UpgradeInfo>();
}