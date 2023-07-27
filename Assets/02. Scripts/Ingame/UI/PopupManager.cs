using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject customerQueue;
    [SerializeField] private GameObject pause;

    [SerializeField] private GameObject goalPopup;
    [SerializeField] private GameObject endPopup;
    [SerializeField] private GameObject pausePopup;
    [SerializeField] private GameObject timeOver;

    public IEnumerator GoalPopup()
    {
        goalPopup.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        goalPopup.SetActive(false);
        timer.SetActive(true);
        score.SetActive(true);
        customerQueue.SetActive(true);
        pause.SetActive(true);
    }

    public void PausePopup()
    {
        pausePopup.SetActive(true);
    }

    public void EndPopup()
    {
        endPopup.SetActive(true);
    }

    public IEnumerator TimeOver()
    {
        timeOver.SetActive(true);
        yield return new WaitForSeconds(3);
        timeOver.SetActive(false);
    }
}
