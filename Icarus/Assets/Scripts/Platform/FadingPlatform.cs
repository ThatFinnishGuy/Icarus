using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    public float fadeTime;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeSprite();
    }

    void FadeSprite()
    {
        Color spriteColor = spriteRenderer.color;
        spriteColor.a -= Time.deltaTime * fadeTime;

        spriteRenderer.color = spriteColor;

        if (spriteColor.a <= 0)
            GameObject.Destroy(gameObject);
    }
}
