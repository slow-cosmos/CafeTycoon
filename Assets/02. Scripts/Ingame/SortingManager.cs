using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SortingManager : MonoBehaviour
{
    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        if(tag == "Cup")
        {
            transform.parent.GetComponent<SortingGroup>().enabled = false;
        }
        renderer.sortingOrder = 10;
    }

    public void OnMouseUp()
    {
        if(tag == "Cup")
        {
            transform.parent.GetComponent<SortingGroup>().enabled = true;
        }
        renderer.sortingOrder = 0;
    }
}
