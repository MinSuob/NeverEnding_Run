using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class UnitManager : MonoBehaviour
{
    [SerializeField] private GameObject ShowCharPrefab;
    [SerializeField] private Transform ShowCharSlot;

    [SerializeField] private Image[] DeckIcon;

    void Start()
    {
        Init();
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
}
