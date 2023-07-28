using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Time,
    Count,
    Cost
}

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

    public List<int> curUpgrades = new List<int>();

    private void Init()
    {
        for(int i=0;i<upgradeData.upgradeList.Count;i++)
        {
            curUpgrades.Add(PlayerPrefs.GetInt("CurUpgrade"+i, 0));
        }
    }
}
