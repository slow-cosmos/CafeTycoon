using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text name;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text detail;

    public void Init(int curIdx)
    {
        UpgradeInfo upgradeInfo = UpgradeManager.Instance.upgradeData.upgradeList[curIdx];
        name.text = upgradeInfo.name;
        image.sprite = upgradeInfo.sprite;
        detail.text = upgradeInfo.upgrade[UpgradeManager.Instance.curUpgrades[curIdx]].ToString();
    }

    public void View(int curIdx)
    {
        UpgradeInfo upgradeInfo = UpgradeManager.Instance.upgradeData.upgradeList[curIdx];
        detail.text = upgradeInfo.upgrade[UpgradeManager.Instance.curUpgrades[curIdx]].ToString();
    }
}
