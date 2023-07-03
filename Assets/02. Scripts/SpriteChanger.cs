using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    
    [SerializeField]
    Sprite[] sprites;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // Menu 클래스는 동적 생성되어 Start에서 실행
        Menu menu = GetComponent<Menu>(); 
        menu.spriteChange += ChangeSprite;
    }

    void ChangeSprite(int index)
    {
        spriteRenderer.sprite = sprites[index];
    }
}
