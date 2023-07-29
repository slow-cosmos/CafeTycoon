using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CoinView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Coin coin;

    [SerializeField] private GameObject coinText;
    [SerializeField] private Image coinImage;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        AddCoin();
    }

    public async UniTask AddCoin()
    {
        Score.Instance.AddScore(coin.Cost);

        coinImage.enabled = false;
        coinText.SetActive(true);
        coinText.GetComponent<TMP_Text>().text = "+"+coin.Cost;

        await UniTask.Delay(1000);
        
        Destroy(transform.parent.gameObject);
    }
}
