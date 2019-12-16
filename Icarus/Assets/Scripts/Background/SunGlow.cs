using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunGlow : MonoBehaviour
{
    private MeshRenderer sunRenderer;

    public float duration;

    void Awake()
    {
        sunRenderer = GetComponent<MeshRenderer>();
        //draw sun in front
        sunRenderer.sortingOrder = 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GlowPulse();
    }

    void GlowPulse()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;

        sunRenderer.material.SetFloat("_GlowScale", amplitude);
    }


}
