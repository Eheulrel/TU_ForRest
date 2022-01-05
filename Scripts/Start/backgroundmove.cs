using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour
{
    private new Renderer renderer;

    public float speed;
    public float offset;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void Update()
    {
        offset = Time.time * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
        
}
