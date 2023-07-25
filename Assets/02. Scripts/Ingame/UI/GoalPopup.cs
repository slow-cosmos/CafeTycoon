using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text goal;
    
    private void Start()
    {
        goal.text = "100"; //임시
    }
}
