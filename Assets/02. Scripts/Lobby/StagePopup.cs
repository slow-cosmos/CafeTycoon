using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StagePopup : MonoBehaviour
{
    [SerializeField] private GameObject upgradePopup;

    [SerializeField] private GameObject stageObject;
    [SerializeField] private GameObject parent;

    [SerializeField] private Sprite[] stageSprites = new Sprite[3]; // 0 : cur, 1 : 이전, 2 : disable
    [SerializeField] private Sprite[] starSprites = new Sprite[3];

    [SerializeField] private int maxStage;
    [SerializeField] private int curStage;

    private void Awake()
    {
        maxStage = Resources.LoadAll("Data/Chapter").Length;
        curStage = SaveManager.Instance.LoadCurStage();

        for(int i=1;i<=maxStage;i++) // 스테이지 생성
        {
            GameObject stage = Instantiate(stageObject, parent.transform);

            ViewStage(stage, i);

            int tmp = i;
            stage.GetComponent<Button>().onClick.AddListener(() => StageButton(tmp));
        }
    }

    private void ViewStage(GameObject stage, int idx)
    {
        stage.transform.GetChild(0).GetComponent<TMP_Text>().text = idx.ToString(); // 스테이지 숫자

        if(idx == curStage) // 현재 스테이지
        {
            stage.GetComponent<Image>().sprite = stageSprites[0];
        }
        else if(idx < curStage) // 이전 스테이지
        {
            stage.GetComponent<Image>().sprite = stageSprites[1];
        }
        else // 이후 스테이지
        {
            stage.GetComponent<Image>().sprite = stageSprites[2];
            stage.GetComponent<Button>().interactable = false; // 버튼 비활성화
        }

        int starCnt = SaveManager.Instance.LoadStageStar(idx);
        if(starCnt == 0) // 못 깬 스테이지는
        {
            stage.transform.GetChild(1).gameObject.SetActive(false); // 별 안보이게
        }
        else
        {
            stage.transform.GetChild(1).GetComponent<Image>().sprite = starSprites[starCnt-1];
        }
    }

    public void StageButton(int stageNum)
    {
        ChapterManager.Instance.CurChapter = stageNum;
        SceneManager.LoadScene("Ingame");
    }

    public void UpgradeButton()
    {
        upgradePopup.SetActive(true);
    }
}
