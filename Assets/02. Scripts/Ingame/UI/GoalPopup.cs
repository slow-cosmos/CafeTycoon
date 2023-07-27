using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text goal;
    
    private void OnEnable()
    {
        goal.text = ChapterManager.Instance.chapterData.StarScore[0].ToString();
    }
}
