using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudParallax : MonoBehaviour
{
    public float scrollSpeedX = 0.3f;
    public float scrollSpeedY = 0.3f;

    private MeshRenderer meshRenderer;
    private string mainTex = "_MainTex";

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(mainTex);

        offset.x += Time.deltaTime * scrollSpeedX;
        offset.y += Time.deltaTime * scrollSpeedY;

        meshRenderer.sharedMaterial.SetTextureOffset(mainTex, offset);
    }
}
