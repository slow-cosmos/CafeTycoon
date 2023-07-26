using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [SerializeField] private PopupManager popupManager;

    private void Awake()
    {
        timer.endGame += EndGame;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        popupManager.StartCoroutine(popupManager.GoalPopup());
    }

    private void EndGame()
    {
        // 못받은 돈 모두 받고
        Time.timeScale = 0;
        popupManager.EndPopup();
    }
}
