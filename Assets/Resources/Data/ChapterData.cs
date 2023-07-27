using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChapterData : ScriptableObject
{
    public float Timer => timer;
    public float TimeGap => timeGap;
    public List<int> StarScore => starScore;

    [SerializeField] private float timer;
    [SerializeField] private float timeGap;
    [SerializeField] private List<int> starScore = new List<int>{0,0,0};
}
