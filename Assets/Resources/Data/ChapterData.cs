using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChapterData : ScriptableObject
{
    public float Timer => timer;
    public float TimeGap => timeGap;
    public int Star1Score => star1Score;
    public int Star2Score => star2Score;
    public int Star3Score => star3Score;

    [SerializeField] private float timer;
    [SerializeField] private float timeGap;
    [SerializeField] private int star1Score;
    [SerializeField] private int star2Score;
    [SerializeField] private int star3Score;
}
