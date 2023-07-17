using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct CustomerInfo
{
    public CustomerType customerType;
    public List<OrderType> orderList;
}

[CreateAssetMenu]
public class CustomerQueueData : ScriptableObject
{
    public int CustomerCount => customerCount;
    public List<CustomerInfo> CustomerList => customerList;

    [SerializeField] private int customerCount;
    [SerializeField] private List<CustomerInfo> customerList = new List<CustomerInfo>();
}
