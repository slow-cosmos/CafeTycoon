using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IMakeMenuObject
{
    [SerializeField] private Holder holder;

    [SerializeField] private bool isWorking = false;
    [SerializeField] private float timer;
    [SerializeField] private float burnedTime;

    public bool isClicked = false;

    private void Awake()
    {
        timer = 3.0f; // 임시 타이머
        burnedTime = 3.0f;
    }

    public void OnMouseDown()
    {
        isClicked = true;
    }

    public void OnMouseUp()
    {
        isClicked = false;
    }

    public void MakeMenu(GameObject dough)
    {
        if(holder.Object == null && isWorking == false)
        {
            StartCoroutine(Bake(dough));
        }
    }

    IEnumerator Bake(GameObject dough)
    {
        isWorking = true;

        yield return new WaitForSeconds(timer);
        Debug.Log("다 구워짐!");

        float time = burnedTime;

        while(time>0)
        {
            time -= Time.deltaTime;
            if(isClicked)
            {
                GameObject menu = Instantiate(dough, holder.transform);
                menu.GetComponent<DoughMenu>().SetBakedType(BakedType.Baked);
                holder.Object = menu;
                isWorking = false;

                yield break;
            }
            yield return null;
            if(time<=0)
            {
                GameObject menu = Instantiate(dough, holder.transform);
                menu.GetComponent<DoughMenu>().SetBakedType(BakedType.Burned);
                holder.Object = menu;
                isWorking = false;
            }
        }
    }
}