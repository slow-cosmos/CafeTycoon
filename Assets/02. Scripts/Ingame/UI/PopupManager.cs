using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject customerQueue;
    [SerializeField] private GameObject customerQueueUI;
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
        customerQueueUI.SetActive(true);
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

    public async UniTask TimeOver()
    {
        timeOver.SetActive(true);
        await UniTask.Delay(3000);
        timeOver.SetActive(false);
    }
}
