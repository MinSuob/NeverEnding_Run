using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;


public class UnitManager : MonoBehaviour
{
    [SerializeField] private GameObject ShowCharPrefab;
    [SerializeField] private Transform ShowCharSlot;
    [SerializeField] private GameObject CurCharPrefab;
    [SerializeField] private Transform CurCharSlot;

    void Start()
    {
        Init();
        CurInit();
    }

    void Update()
    {
        
    }

    private void Init()
    {
        foreach (Job job in Enum.GetValues(typeof(Job)))
        {
            GameObject ShowChar = null;
            ShowChar = Instantiate(ShowCharPrefab, ShowCharSlot);
            ShowChar.GetComponent<ShowCharImage>().ShowImage(job);
        }
    }
    private void CurInit()
    {
        foreach (Job job in Enum.GetValues(typeof(Job)))
        {
            GameObject ShowChar = null;
            ShowChar = Instantiate(CurCharPrefab, CurCharSlot);
            ShowChar.GetComponent<ShowCharIcon>().ShowIcon(job);
        }
    }
}
