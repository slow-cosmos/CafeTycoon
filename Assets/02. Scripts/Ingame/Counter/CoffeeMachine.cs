using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour, IMakeMenu
{
    public GameObject coffeeObject;

    public Animator animator;

    [SerializeField] private Holder holder;

    [SerializeField] private Machines machines;

    public bool isWorking = false;
    [SerializeField] private float timer;
    WaitForSeconds waitMachine;

    private void Awake()
    {
        machines = gameObject.transform.parent.GetComponent<Machines>();
        timer = UpgradeManager.Instance.GetUpgrade("EspressoMachine:Time");
        waitMachine = new WaitForSeconds(timer);
    }
    
    private void OnMouseDown()
    {
        MakeMenu();
    }

    public void MakeMenu()
    {
        List<GameObject> emptyList = GetEmptyList();
        if(emptyList.Count != 0)
        {
            foreach(var machine in emptyList)
            {
                CoffeeMachine coffeeMachine = machine.GetComponent<CoffeeMachine>();
                coffeeMachine.StartCoroutine(coffeeMachine.CoffeeGenerate());
            }
            SoundManager.Instance.PlayEffect("espressomachine");
        }
    }

    public IEnumerator CoffeeGenerate()
    {
        animator.SetInteger("State", 1);

        isWorking = true;

        yield return new WaitForSeconds(0.4f); // 애니메이션 기다리기

        animator.SetInteger("State", 2);
        yield return waitMachine;

        animator.SetInteger("State", 3);
        yield return new WaitForSeconds(0.1f); // 애니메이션 기다리기

        GameObject menu = Instantiate(coffeeObject, holder.transform);

        holder.Object = menu;
        isWorking = false;

        while(holder.Object != null)
        {
            yield return null;
        }

        animator.SetInteger("State", 0);
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
