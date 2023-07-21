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
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;

    public Sprite[] sprites = new Sprite[2];
    public string[] strings = new string[2];

    public void ChangeDialog(DialogType dialog)
    {
        StartCoroutine(StartChangeDialog(dialog));
    }

    IEnumerator StartChangeDialog(DialogType dialog)
    {
        image.gameObject.SetActive(true);
        text.gameObject.SetActive(true);

        image.sprite = sprites[(int)dialog];
        text.text = strings[(int)dialog];

        yield return new WaitForSeconds(1);

        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
}
