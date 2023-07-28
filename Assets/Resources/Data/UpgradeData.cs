using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct UpgradeInfo
{
    public string name;
    public Sprite sprite;

    public UpgradeType upgradeType; // 업그레이드 타입
    public List<int> upgrade; // 업그레이드 정보
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public List<UpgradeInfo> upgradeList = new List<UpgradeInfo>();
}