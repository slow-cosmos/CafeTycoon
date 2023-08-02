using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    #region Singleton
    private static SaveManager instance;
    public static SaveManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SaveManager();
            }
            return instance;
        }
    }
    #endregion

    public int LoadCurStage() // 현재 스테이지 로드
    {
        int stage = PlayerPrefs.GetInt("CurStage", 1);
        Debug.Log("CurStage 로드 : "+stage);
        return stage;
    }

    public int LoadStageStar(int stage) // 스테이지 별 개수
    {
        int star = PlayerPrefs.GetInt("Stage"+stage, 0);
        Debug.Log("Stage"+stage+" 별 개수 로드 : "+star);
        return star;
    }

    public void SaveCurStage(int stage)
    {
        Debug.Log("CurStage 저장 : "+stage);
        PlayerPrefs.SetInt("CurStage", stage);
    }

    public void SaveStageStar(int stage, int star)
    {
        Debug.Log("Stage"+stage+" 별 개수 저장 : "+star);
        PlayerPrefs.SetInt("Stage"+stage, star);
    }

    public void StageClear(int stage, int star)
    {
        if(LoadCurStage() == stage && star > 0) // 현재 스테이지를 깼을 경우 갱신
        {
            Debug.Log("현재 스테이지 깸");
            SaveCurStage(stage+1);
        }
        if(LoadStageStar(stage) < star) // 현재 점수가 더 높을 경우 저장
        {
            Debug.Log("점수 갱신");
            SaveStageStar(stage, star);
        }
    }
}
