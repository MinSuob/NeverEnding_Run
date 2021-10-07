using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class ShowCharImage : MonoBehaviour
{
    DataManager dm;

    [SerializeField] private Image CharImage;
    [SerializeField] private Image CharIcon;
    [SerializeField] private Text GradeText;
    [SerializeField] private Slider PieceSlider;
    [SerializeField] private Text PieceText;

    private Job job;

    private List<string> DeckData = new List<string>();

    void Start()
    {
        dm = DataManager.Instance;
    }

    void Update()
    {
        PieceSlider.value = dm.GetUnitData(job).Piece / dm.GetUnitData(job).MaxPiece;
        PieceText.text = dm.GetUnitData(job).Piece + " / 20";
        GradeText.text = dm.GetUnitData(job).Grade.ToString();
        if(((int)(dm.GetUnitData(job).Job)) > 12 && dm.GetUnitData(job).Piece == 0)
            CharImage.color = new Color(80 / 255f, 80 / 255f, 80 / 255f, 255);
        else
            CharImage.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255);
    }

    public void ShowImage(Job job)
    {
        this.job = job;
        CharImage.sprite = Resources.Load<Sprite>("CharImg/" + job);
    }

    public void Info_Button() // Unit Info Open Button
    {
        CurrentCharacter.Instance.Unit_Info(this.job);
    }
}
