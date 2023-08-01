using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeDictionary : SerializableDictionary<string, int>{} // dictionary 인스펙터 표시

public class UpgradeManager : MonoBehaviour
{
    #region Singleton
    private static UpgradeManager instance;
    public static UpgradeManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Init();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public UpgradeData upgradeData;

    [SerializeField] private UpgradeDictionary curUpgrade = new UpgradeDictionary();

    private void Init() // 현재 업그레이드 정보 로드
    {
        for(int i=0;i<GetUpgradeListCount();i++)
        {
            string key = GetCurUpgradeKey(i);
            curUpgrade.Add(key,PlayerPrefs.GetInt(key,0));
        }
    }

    public int GetUpgradeListCount() // 전체 업그레이드 리스트 개수
    {
        return upgradeData.UpgradeList.Count;
    }

    public UpgradeInfo GetUpgradeInfo(string key) // 하나 업그레이드 정보
    {
        string[] keys = key.Split(':');
        return upgradeData.UpgradeList.Find(x => x.upgradeObject.ToString() == keys[0] && x.upgradeType.ToString() == keys[1]);
    }

    public int GetUpgrade(string key)
    {
        return GetUpgradeInfo(key).upgrade[GetCurUpgradeValue(key)];
    }

    public string GetCurUpgradeKey(int idx) // 저장, 로드할 때 필요한 dictionary 키
    {
        return $"{upgradeData.UpgradeList[idx].upgradeObject.ToString()}:{upgradeData.UpgradeList[idx].upgradeType.ToString()}";
    }

    public int GetCurUpgradeValue(string key) // dictionary 값 가져오기
    {
        return curUpgrade[key];
    }

    public void SetCurUpgradeValue(string key, int value) // dictionary 값 변경
    {
        curUpgrade[key] = value;
    }
}
