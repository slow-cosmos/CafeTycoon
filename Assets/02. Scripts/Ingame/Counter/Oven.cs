using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IMakeMenuObject
{
    [SerializeField] Animator animator;

    [SerializeField] private Holder holder;

    [SerializeField] private bool isWorking = false;
    [SerializeField] private float timer;
    [SerializeField] private float burnedTime;

    public bool isClicked = false;

    private void Awake()
    {
        timer = UpgradeManager.Instance.GetUpgrade("Oven:Time");
        burnedTime = 5.0f;
    }

    public void MakeMenu(GameObject dough)
    {
        if(holder.Object == null && isWorking == false)
        {
            StartCoroutine(Bake(dough));
        }
    }

    private IEnumerator Bake(GameObject dough)
    {
        animator.SetInteger("State", 2);
        if(dough.GetComponent<DoughMenu>().Dough == DoughType.Doughnut)
        {
            animator.SetInteger("Dough", 1);
        }
        else
        {
            animator.SetInteger("Dough", 2);
        }
        isWorking = true;

        yield return new WaitForSeconds(timer);

        animator.SetInteger("State", 3);
        SoundManager.Instance.PlayEffect("ovenmachine");
        Debug.Log("다 구워짐!");

        float time = burnedTime;

        while(time>0)
        {
            time -= Time.deltaTime;
            if(isClicked)
            {
                animator.SetInteger("State", 4);

                GameObject menu = Instantiate(dough, holder.transform);
                menu.GetComponent<DoughMenu>().Baked = BakedType.Baked;
                holder.Object = menu;
                isWorking = false;

                StartCoroutine(WaitExitAnimator());

                yield break;
            }
            yield return null;
            if(time<=0)
            {
                animator.SetInteger("State", 4);
                SoundManager.Instance.PlayEffect("burning");

                GameObject menu = Instantiate(dough, holder.transform);
                menu.GetComponent<DoughMenu>().Baked = BakedType.Burned;
                holder.Object = menu;
                isWorking = false;

                StartCoroutine(WaitExitAnimator());
            }
        }
    }

    private IEnumerator WaitExitAnimator()
    {
        while(holder.Object != null)
        {
            yield return null;
        }
        animator.SetInteger("State", 0);
        animator.SetInteger("Dough", 0);
    }

    public void OnMouseDown()
    {
        isClicked = true;
    }

    public void OnMouseUp()
    {
        isClicked = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Dough")
        {
            animator.SetInteger("State", 1);
        }
    }

    private void OnTriggerExit()
    {
        if(animator.GetInteger("Dough") == 0)
        {
            animator.SetInteger("State", 0);
        }
    }
}