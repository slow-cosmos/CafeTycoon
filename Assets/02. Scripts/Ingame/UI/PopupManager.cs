using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject customerQueue;

    [SerializeField] private GameObject goalPopup;
    [SerializeField] private GameObject endPopup;

    public IEnumerator GoalPopup()
    {
        goalPopup.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        goalPopup.SetActive(false);
        timer.SetActive(true);
        score.SetActive(true);
        customerQueue.SetActive(true);
    }

    public void PausePopup()
    {
        
    }

    public void EndPopup()
    {
        //타임오버
        endPopup.SetActive(true);
    }
}
