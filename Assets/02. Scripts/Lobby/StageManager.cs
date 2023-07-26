using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject stageObject;

    [SerializeField] private int maxStage;

    private void Awake()
    {
        //maxStage = 5; // 임시

        for(int i=1;i<=maxStage;i++)
        {
            GameObject stage = Instantiate(stageObject, gameObject.transform);
            stage.transform.GetChild(0).GetComponent<TMP_Text>().text = i.ToString();

            int tmp = i;
            stage.GetComponent<Button>().onClick.AddListener(() => StageButton(tmp));
        }
    }

    public void StageButton(int stageNum)
    {
        ChapterManager.Instance.CurChapter = stageNum;
        SceneManager.LoadScene("Ingame");
    }
}
