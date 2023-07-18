using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour, IMakeMenu
{
    public GameObject coffeeObject;

    [SerializeField] private Machines machines;

    public bool isWorking = false;
    [SerializeField] private float timer;

    void Awake()
    {
        machines = gameObject.transform.parent.GetComponent<Machines>();
        timer = 3.0f; // 임시 타이머
    }
    
    void OnMouseDown()
    {
        MakeMenu();
    }

    public void MakeMenu()
    {
        StartCoroutine(CoffeeGenerate());
    }

    IEnumerator CoffeeGenerate()
    {
        List<GameObject> emptyList = GetEmptyList();
        if(emptyList.Count != 0)
        {
            Debug.Log("에스프레소 생성 시작");
            foreach(var machine in emptyList)
            {
                machine.GetComponent<CoffeeMachine>().isWorking = true;
            }

            yield return new WaitForSeconds(timer);

            foreach(var machine in emptyList)
            {
                Holder holder = machine.gameObject.transform.GetChild(0).GetComponent<Holder>();
                GameObject menu = Instantiate(coffeeObject, holder.transform);
                holder.Object = menu;
                machine.GetComponent<CoffeeMachine>().isWorking = false;
            }
        }
    }

    public List<GameObject> GetEmptyList()
    {
        List<GameObject> emptyList = new List<GameObject>();
        List<GameObject> machinesList = machines.MachinesList;
        for(int i=0;i<machines.MachineCount;i++) // 활성화된 머신 중에
        {
            Holder holder = machinesList[i].transform.GetChild(0).GetComponent<Holder>();
            CoffeeMachine machine = machinesList[i].GetComponent<CoffeeMachine>();
            if(!machine.isWorking && holder.Object == null) // 홀더가 비어있고, 머신이 작동 중이지 않은
            {
                emptyList.Add(machinesList[i]);
            }
        }
        return emptyList;
    }
}
