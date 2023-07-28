using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePopup : MonoBehaviour
{
    [SerializeField] private GameObject upgradeObject;
    [SerializeField] private GameObject parent;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for(int i=0;i<UpgradeManager.Instance.upgradeData.upgradeList.Count;i++)
        {
            int tmp = i;
            UpgradeInfo upgradeInfo = UpgradeManager.Instance.upgradeData.upgradeList[i];

            GameObject obj = Instantiate(upgradeObject, parent.transform);
            obj.transform.Find("Upgrade").GetComponent<Button>().onClick.AddListener(() => UpgradeButton(tmp));
            obj.transform.Find("Downgrade").GetComponent<Button>().onClick.AddListener(() => DowngradeButton(tmp));
            obj.GetComponent<Upgrade>().Init(i);
        }
    }

    public void UpgradeButton(int curIdx)
    {
        if(UpgradeManager.Instance.curUpgrades[curIdx]+1 < UpgradeManager.Instance.upgradeData.upgradeList[curIdx].upgrade.Count)
        {
            UpgradeManager.Instance.curUpgrades[curIdx] += 1;
            
            int curUpgrade = UpgradeManager.Instance.curUpgrades[curIdx];
            PlayerPrefs.SetInt("CurUpgrade"+curIdx, curUpgrade);
            parent.transform.GetChild(curIdx).GetComponent<Upgrade>().View(curIdx);
        }
        else
        {
            Debug.Log("최대 업그레이드 수보다 높음");
        }
    }

    public void DowngradeButton(int curIdx)
    {
        if(UpgradeManager.Instance.curUpgrades[curIdx] > 0)
        {
            UpgradeManager.Instance.curUpgrades[curIdx] -= 1;
            
            int curUpgrade = UpgradeManager.Instance.curUpgrades[curIdx];
            PlayerPrefs.SetInt("CurUpgrade"+curIdx, curUpgrade);
            parent.transform.GetChild(curIdx).GetComponent<Upgrade>().View(curIdx);
        }
        else
        {
            Debug.Log("더 다운그레이드 할 수 없음");
        }
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
