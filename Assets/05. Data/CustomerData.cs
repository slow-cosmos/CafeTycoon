using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="CustomerData", fileName="CustomerData")]
public class CustomerData : ScriptableObject
{
    public float Timer => timer;
    public float TimeSpeed => timeSpeed;
    [SerializeField] private float timer;
    [SerializeField] private float timeSpeed;
}
