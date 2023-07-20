using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour, IPointerClickHandler
{
    public GameObject coinText;
    public Image coinImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(CoinText());
    }

    IEnumerator CoinText()
    {
        coinImage.enabled = false;
        coinText.SetActive(true);
        coinText.GetComponent<TMP_Text>().text = "+"+gameObject.transform.parent.GetComponent<Customer>().cost;
        yield return new WaitForSeconds(1);
        Destroy(transform.parent.gameObject);
    }
}
