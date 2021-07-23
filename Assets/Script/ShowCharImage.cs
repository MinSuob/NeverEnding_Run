using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class ShowCharImage : MonoBehaviour
{
    [SerializeField] private Image CharImage;

    public Job job;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowImage(Job job)
    {
        this.job = job;
        CharImage.sprite = Resources.Load<Sprite>("CharImg/" + job);
    }
}
