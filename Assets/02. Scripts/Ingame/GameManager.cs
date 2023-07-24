using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject score;

    private void Start()
    {
        timer.SetActive(true);
        score.SetActive(true);

        
    }
}
