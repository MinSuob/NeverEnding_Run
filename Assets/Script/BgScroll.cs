using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    MeshRenderer Render;
    float Offset;

    public float Speed;

    void Start()
    {
        Render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Offset += Time.deltaTime * Speed;
        Render.material.mainTextureOffset = new Vector2(Offset, 0);
    }
}
