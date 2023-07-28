using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private IEnumerator EndGame()
    {
        if(gameState != GameState.End) // 게임모드가 End가 아니면 (중복 방지)
        {
            gameState = GameState.End;
            if(timer.IsEnd) // 타이머가 끝났다면
            {
                customerQueue.ComeOutCustomer();
                popupManager.StartCoroutine(popupManager.TimeOver());
                yield return new WaitForSeconds(3);
                customerQueue.GetAllCoin();
                yield return new WaitForSeconds(1);
            }
            else // 손님이 더 없어서 끝났다면
            {
                yield return new WaitForSeconds(1.5f);
                customerQueue.GetAllCoin();
                yield return new WaitForSeconds(1);
                // 남은 시간을 점수에 추가
            }
            popupManager.EndPopup();
        }
    }

    public void PauseGame()
    {
        popupManager.PausePopup();
    }
}
