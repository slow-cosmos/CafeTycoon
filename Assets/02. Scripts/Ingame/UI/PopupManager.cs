using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject customerQueue;

    [SerializeField] private GameObject goalPopup;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        goalPopup.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        goalPopup.SetActive(false);
        timer.SetActive(true);
        score.SetActive(true);
        customerQueue.SetActive(true);
    }

    private void PauseGame()
    {
        
    }

    private void EndGame()
    {
        // 최종 점수 팝업
    }
}
