using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    #region Singleton
    private static ChapterManager instance;
    public static ChapterManager Instance
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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [SerializeField] private int curChapter;
    public int CurChapter
    {
        get
        {
            return curChapter;
        }
        set
        {
            curChapter = value;
            Init();
        }
    }

    public ChapterData chapterData;
    public CustomerQueueData customerQueueData;

    private void Init()
    {
        string path1 = "Data/Chapter/"+curChapter;
        chapterData = Resources.Load<ChapterData>(path1);

        string path2 = "Data/CustomerQueue/"+curChapter;
        customerQueueData = Resources.Load<CustomerQueueData>(path2);
    }
}
