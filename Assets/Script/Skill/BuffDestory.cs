using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDestory : MonoBehaviour
{
    [SerializeField] float time;
    void Start()
    {
        Destroy(gameObject,time);
    }

    void Update()
    {
        
    }
}
