using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Pick : MonoBehaviour
{
    private Transform transform;
    private SpriteRenderer renderer;
    private SortingGroup sorting = null;

    private Vector3 originScale;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        renderer = GetComponent<SpriteRenderer>();
        sorting = transform.parent.GetComponent<SortingGroup>();
        originScale = transform.localScale;
    }

    public void OnMouseDown()
    {
        if(sorting != null)
        {
            sorting.enabled = false;
        }
        renderer.sortingOrder = 10;
        transform.localScale = originScale * 1.2f;
    }

    public void OnMouseUp()
    {
        if(sorting != null)
        {
            sorting.enabled = true;
        }
        renderer.sortingOrder = 0;
        transform.localScale = originScale;
    }
}
