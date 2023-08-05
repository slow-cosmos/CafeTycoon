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
        burnedTime = 3.0f;
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
        animator.SetBool("isBaking", true);
        isWorking = true;

        yield return new WaitForSeconds(timer);

        animator.SetBool("isBakingComplete", true);
        Debug.Log("다 구워짐!");

        float time = burnedTime;

        while(time>0)
        {
            time -= Time.deltaTime;
            if(isClicked)
            {
                animator.SetBool("isComplete", true);

                GameObject menu = Instantiate(dough, holder.transform);
                menu.GetComponent<DoughMenu>().SetBakedType(BakedType.Baked);
                holder.Object = menu;
                isWorking = false;

                StartCoroutine(WaitExitAnimator());

                yield break;
            }
            yield return null;
            if(time<=0)
            {
                animator.SetBool("isComplete", true);

                GameObject menu = Instantiate(dough, holder.transform);
                menu.GetComponent<DoughMenu>().SetBakedType(BakedType.Burned);
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
        animator.SetBool("isComplete", false); // 처음 애니메이션으로 돌아가기
        animator.SetBool("isOpen", false); // 애니메이션 초기화
        animator.SetBool("isBaking", false);
        animator.SetBool("isBakingComplete", false);
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
            animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit()
    {
        animator.SetBool("isOpen", false);
    }
}