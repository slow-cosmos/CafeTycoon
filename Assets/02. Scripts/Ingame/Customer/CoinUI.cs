using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CoinUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Coin coin;

    [SerializeField] private GameObject coinText;
    [SerializeField] private Image coinImage;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Score.Instance.FillScoreGauge(coin.Cost);
        StartCoroutine(CoinText());
    }

    IEnumerator CoinText()
    {
        coinImage.enabled = false;
        coinText.SetActive(true);
        coinText.GetComponent<TMP_Text>().text = "+"+coin.Cost;
        yield return new WaitForSeconds(1);
        Destroy(transform.parent.gameObject);
    }
}
