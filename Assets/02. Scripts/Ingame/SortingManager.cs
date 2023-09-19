using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SortingManager : MonoBehaviour
{
    private SpriteRenderer renderer;
    private SortingGroup sorting = null;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        sorting = transform.parent.GetComponent<SortingGroup>();
    }

    public void OnMouseDown()
    {
        if(sorting != null)
        {
            sorting.enabled = false;
        }
        renderer.sortingOrder = 10;
    }

    public void OnMouseUp()
    {
        if(sorting != null)
        {
            sorting.enabled = true;
        }
        renderer.sortingOrder = 0;
    }
}
