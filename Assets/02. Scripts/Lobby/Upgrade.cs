using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private RectTransform gradeRect;
    [SerializeField] private Image[] grade;
    [SerializeField] private Sprite[] gradeSprite;
    [SerializeField] private TMP_Text name;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text current;
    [SerializeField] private TMP_Text next;
    [SerializeField] private TMP_Text type;

    private UpgradeInfo upgradeInfo;

    public void Init(string key)
    {
        upgradeInfo = UpgradeManager.Instance.GetUpgradeInfo(key);
        name.text = upgradeInfo.name;

        image.sprite = upgradeInfo.sprite;
        image.rectTransform.sizeDelta = new Vector3(upgradeInfo.sprite.bounds.size.x * 100, upgradeInfo.sprite.bounds.size.y * 100, 0);
        image.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        switch (upgradeInfo.upgrade.Count)
        {
            case 3:
                gradeRect.sizeDelta = new Vector2(70, 40);
                break;
            case 4:
                gradeRect.sizeDelta = new Vector2(90, 40);
                break;
        }

        for (int i = 0; i < upgradeInfo.upgrade.Count; i++)
        {
            grade[i].gameObject.SetActive(true);
        }

        switch (upgradeInfo.upgradeType)
        {
            case UpgradeType.Count:
                type.text = "생산(보관)수량증가";
                break;
            case UpgradeType.Time:
                type.text = "작업시간단축(초)";
                break;
            case UpgradeType.Cost:
                type.text = "판매가격상승";
                break;
        }

        View(key);
    }

    public void View(string key)
    {
        int curUpgrade = UpgradeManager.Instance.GetCurUpgradeValue(key);
        current.text = upgradeInfo.upgrade[curUpgrade].ToString();
        next.text = curUpgrade + 1 == upgradeInfo.upgrade.Count ? upgradeInfo.upgrade[curUpgrade].ToString() : upgradeInfo.upgrade[curUpgrade + 1].ToString();

        for (int i = 0; i <= curUpgrade; i++) // grade 표시
        {
            grade[i].sprite = gradeSprite[1];
        }
        for (int i = curUpgrade + 1; i < upgradeInfo.upgrade.Count; i++)
        {
            grade[i].sprite = gradeSprite[0];
        }
    }
}
