using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] Animator animator;
    private Collider obj;

    private void Update()
    {
        if(obj == null)
        {
            animator.SetInteger("State", 0);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        obj = col;
        animator.SetInteger("State", 1);
    }

    private void OnTriggerExit(Collider col)
    {
        animator.SetInteger("State", 0);
    }
}
