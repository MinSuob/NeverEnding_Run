using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;

public class ShowCharIcon : MonoBehaviour
{
    DataManager dm;

    private Job job;
    [SerializeField] private Image CharIcon;

    private void Start()
    {
        dm = DataManager.Instance;
    }

    private void Update()
    {
        if (((int)(dm.GetUnitData(job).Job)) > 12 && dm.GetUnitData(job).Piece == 0)
            CharIcon.color = new Color(80 / 255f, 80 / 255f, 80 / 255f, 255);
        else
            CharIcon.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255);
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
}
