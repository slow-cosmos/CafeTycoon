using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum DialogType
{
    Warning,
    Fail,
    Success
}

public class Dialog : MonoBehaviour
{
    [SerializeField] private RectTransform imageTransform;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;

    public Sprite[] sprites = new Sprite[3];
    public string[] strings = new string[3];

    public IEnumerator ChangeDialog(DialogType dialog)
    {
        int idx = (int)dialog;

        image.gameObject.SetActive(true);
        text.gameObject.SetActive(true);

        image.sprite = sprites[idx];
        text.text = strings[idx];

        imageTransform.sizeDelta = sprites[idx].bounds.size*100;

        yield return new WaitForSeconds(1);

        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}
