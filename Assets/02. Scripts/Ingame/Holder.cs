using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    [SerializeField] private GameObject obj = null;
    public GameObject Object
    {
        get
        {
            return obj;
        }
        set
        {
            obj = value;
        }
    }
}
