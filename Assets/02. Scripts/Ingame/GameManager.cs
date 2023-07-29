using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public enum GameState
{
    Play,
    End,
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private CustomerQueue customerQueue;

    [SerializeField] private PopupManager popupManager;

    [SerializeField] private GameState gameState;

    private void Awake()
    {
        timer.endGame += EndGame;
        customerQueue.endGame += EndGame;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        gameState = GameState.Play;
        popupManager.StartCoroutine(popupManager.GoalPopup());
    }

    private async UniTask EndGame()
    {
        if(gameState != GameState.End) // 게임모드가 End가 아니면 (중복 방지)
        {
            gameState = GameState.End;
            if(timer.IsEnd) // 타이머가 끝났다면
            {
                Debug.Log("타이머 끝!");
                await customerQueue.EndCustomerQueue();
                await popupManager.TimeOver();
            }
            else
            {
                Debug.Log("손님 끝!");
                await UniTask.Delay(3000);
            }
            await customerQueue.GetAllCoin();
            popupManager.EndPopup();
        }
    }

    public void PauseGame()
    {
        popupManager.PausePopup();
    }
}
