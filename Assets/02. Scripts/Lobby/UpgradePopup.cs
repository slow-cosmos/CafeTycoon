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
        for(int i=0;i<UpgradeManager.Instance.GetUpgradeListCount();i++)
        {
            GameObject obj = Instantiate(upgradeObject, parent.transform);

            string key = UpgradeManager.Instance.GetCurUpgradeKey(i);
            int idx = i;
            obj.transform.Find("Upgrade").GetComponent<Button>().onClick.AddListener(() => UpgradeButton(idx, key));
            obj.transform.Find("Downgrade").GetComponent<Button>().onClick.AddListener(() => DowngradeButton(idx, key));
            obj.GetComponent<Upgrade>().Init(key);
        }
    }

    public void UpgradeButton(int idx, string key)
    {
        int value = UpgradeManager.Instance.GetCurUpgradeValue(key)+1;
        if(value < UpgradeManager.Instance.GetUpgradeInfo(key).upgrade.Count)
        {
            UpgradeManager.Instance.SetCurUpgradeValue(key, value);
            PlayerPrefs.SetInt(key, value);
            parent.transform.GetChild(idx).GetComponent<Upgrade>().View(key);
        }
        else
        {
            Debug.Log("최대 업그레이드 수보다 높음");
        }
    }

    public void DowngradeButton(int idx, string key)
    {
        int value = UpgradeManager.Instance.GetCurUpgradeValue(key)-1;
        if(value >= 0)
        {
            UpgradeManager.Instance.SetCurUpgradeValue(key, value);
            PlayerPrefs.SetInt(key, value);
            parent.transform.GetChild(idx).GetComponent<Upgrade>().View(key);
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
