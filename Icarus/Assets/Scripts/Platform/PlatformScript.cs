using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 6f;

    public bool isMovingPlatformLeft, isMovingPlatformRight, 
                isFadingPlatform, isFlamingPlatform, 
                isStandardPlatform;

    private Animator anim;

    void Awake()
    {
        if (isFadingPlatform) { }
            //fading logic
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;

        transform.position = temp;

        if (temp.y >= boundY)
            gameObject.SetActive(false);
    }
}
