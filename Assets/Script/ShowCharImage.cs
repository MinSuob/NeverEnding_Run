using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class ShowCharImage : MonoBehaviour
{
    [SerializeField] private Image CharImage;
    [SerializeField] private Image CharIcon;
    [SerializeField] private Text GradeText;

    private Job job;

    private List<string> DeckData = new List<string>();

    void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();

    }

    void Update()
    {
        
    }

    public void ShowImage(Job job)
    {
        this.job = job;
        CharImage.sprite = Resources.Load<Sprite>("CharImg/" + job);
        GradeText.text = DataManager.Instance.GetUnitData(job).Grade.ToString();

    }

    public void ShowIcon(Job job)
    {
        this.job = job;
        CharIcon.sprite = Resources.Load<Sprite>("CharIcon/" + job);
    }

    public void Choice_Button() // Cur Unit Choice Button
    {
        CurrentCharacter.Instance.ChoiceChar(this.job);
    }

    public void Info_Button() // Unit Info Open Button
    {
        CurrentCharacter.Instance.Unit_Info(this.job);
    }
}
