using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour, IMakeMenu
{
    public GameObject juiceObject;

    [SerializeField]
    Group group;

    [SerializeField]
    float timer;

    [SerializeField]
    bool isWorking = false;

    void Awake()
    {
        timer = 3.0f; // 임시 타이머
    }
    
    void OnMouseDown()
    {
        if(!isWorking)
        {
            MakeMenu();
        }
    }

    public void MakeMenu()
    {
        StartCoroutine(JuiceGenerate());
    }

    IEnumerator JuiceGenerate()
    {
        Debug.Log("주스 생성 시작");
        isWorking = true;
        yield return new WaitForSeconds(timer);

        List<Holder> emptyList = GetEmptyList();
        if(emptyList.Count != 0)
        {         
            foreach(var holder in emptyList)
            {
                GameObject menu = Instantiate(juiceObject, holder.transform);
                holder.menu = menu;
            }
        }

        isWorking = false;
    }

    public List<Holder> GetEmptyList()
    {
        List<Holder> emptyList = new List<Holder>();
        List<GameObject> holders = group.GetObjects();
        for(int i=0;i<group.GetObjectsCount();i++) // 활성화된 홀더 중에
        {
            Holder holder = holders[i].GetComponent<Holder>();
            if(holder.menu == null) // 홀더가 비어있는
            {
                emptyList.Add(holder);
            }
        }
        return emptyList;
    }
}
