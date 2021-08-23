using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;

public class CurrentCharacter: MonoBehaviour
{
    #region SINGLETON
    private static CurrentCharacter instance;
    public static CurrentCharacter Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    DataManager Dm;

    public GameObject ChoicePanel;

    private List<string> DeckData = new List<string>();

    private int CurSlot;

    [SerializeField] private Transform CurChars;

    private float xPos = 0;

    [SerializeField] private Image[] CurIcon;
    private int IconNum = 0;
    private int IconDel = 0;
    [SerializeField] private GameObject IconSlot;

    [SerializeField] private GameObject ErrorPanel;
    [SerializeField] private Text ErrorText;
    [SerializeField] private bool ErrorPanelOn;

    [SerializeField] private GameObject UnitInfoPanel;
    [SerializeField] private Text[] UnitInfoText;
    [SerializeField] private Image[] UnitInfoImg;
    [SerializeField] private Slider UnitPiece;

    [SerializeField] private Text NeedGoldText;
    float NeedGold;
    Color FlashColor = new Color(214 / 255f, 214 / 255f, 214 / 255f, 255);

    public Job CurrentJob;

    void Start()
    {
        Dm = DataManager.Instance;
        DeckData = Dm.GetDeckData();

        CurPlaySet(false);
    }

    public void CurPlaySet(bool Remove)
    {
        if (Remove)
        {
            CurIcon[4].gameObject.SetActive(false);
            DeckData[4] = "empty";
            Destroy(GameObject.Find(DeckData[4] + "(Clone)"));
        }

        xPos = 0;
        IconNum = 0;
        IconDel = 0;

        foreach (string Char in DeckData)
        {
            Destroy(GameObject.Find(Char + "(Clone)"));
            CurIcon[IconDel].gameObject.SetActive(false);
        }

        foreach (string Char in DeckData)
        {
            if (Char != "empty")
            {
                GameObject CurCharList = Resources.Load<GameObject>("SPUM/SPUM_Units/" + Char);
                GameObject CurChar = null;
                CurChar = Instantiate(CurCharList, CurChars);
                CurChar.transform.localPosition = new Vector2(xPos, 0.45f);
                CurChar.transform.localScale = new Vector2(1, 1);
                xPos -= 0.6f;

                CurIcon[IconNum].gameObject.SetActive(true);
                CurIcon[IconNum].sprite = Resources.Load<Sprite>("CharIcon/" + Char);
                IconNum++;
            }
        }
    }

    void Update()
    {

    }

    public void ShowCurChar(int Num)
    {
        ChoicePanel.SetActive(true);
        if (Num == 0)
        {
            IconSlot.SetActive(false);
        }
        else
            IconSlot.SetActive(true);

        switch (Num)
        {
            case 0:
                CurSlot = Num;
                break;
            case 1:
                CurSlot = Num;
                break;
            case 2:
                if (DeckData[1] == "empty")
                {
                    if (ErrorPanelOn == false)
                    {
                        StartCoroutine(ShowErrorText("2번 슬롯이 비어있습니다."));
                    }
                    ChoicePanel.SetActive(false);
                    break;
                }
                CurSlot = Num;
                break;
            case 3:
                if (DeckData[2] == "empty")
                {
                    if (ErrorPanelOn == false)
                    {
                        StartCoroutine(ShowErrorText("3번 슬롯이 비어있습니다."));
                    }
                    ChoicePanel.SetActive(false);
                    break;
                }
                CurSlot = Num;
                break;
            case 4:
                if (DeckData[3] == "empty")
                {
                    if (ErrorPanelOn == false)
                    {
                        StartCoroutine(ShowErrorText("4번 슬롯이 비어있습니다."));
                    }
                    ChoicePanel.SetActive(false);
                    break;
                }
                CurSlot = Num;
                break;
        }
    }
    public void ChoiceChar(Job job)
    {
        if (ErrorPanelOn == false)
        {
            if (DeckData.Contains(job.ToString()))
            {
                StartCoroutine(ShowErrorText("이미 영웅이 존재합니다."));
            }
            else
            {
                if (CurSlot != 0)
                {
                    if (Dm.GetUnitData(job).AtkType == "Melee")
                    {
                        StartCoroutine(ShowErrorText("근접 유닛은 1번 슬롯에만 장착할 수 있습니다."));
                        ChoicePanel.SetActive(false);
                        return;
                    }
                }

                Destroy(GameObject.Find(DeckData[CurSlot] + "(Clone)"));
                DeckData[CurSlot] = job.ToString();
                CurPlaySet(false);
            }
            ChoicePanel.SetActive(false);
        }
    }

    public IEnumerator ShowErrorText(string text)
    {
        ErrorPanelOn = true;
        ErrorPanel.SetActive(true);
        ErrorText.text = text.ToString();

        ErrorPanel.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);
        ErrorPanel.SetActive(false);
        ErrorPanel.transform.position = new Vector2(540, 860);
        ErrorPanelOn = false;
    }

    public void RemoveChar()
    {
        ChoicePanel.SetActive(false);
        switch (CurSlot)
        {
            case 1:
                Destroy(GameObject.Find(DeckData[CurSlot] + "(Clone)"));

                for (int i = CurSlot; i < 4; i++)
                {
                    CurIcon[i].sprite = Resources.Load<Sprite>("CharIcon/" + CurIcon[i + 1]);
                    DeckData[i] = DeckData[i + 1];
                    if (DeckData[i] == "empty")
                    {
                        CurIcon[i].gameObject.SetActive(false);
                    }
                }

                CurPlaySet(true);
                break;
            case 2:
                Destroy(GameObject.Find(DeckData[CurSlot] + "(Clone)"));

                for (int i = CurSlot; i < 4; i++)
                {
                    CurIcon[i].sprite = Resources.Load<Sprite>("CharIcon/" + CurIcon[i + 1]);
                    DeckData[i] = DeckData[i + 1];
                    if (DeckData[i] == "empty")
                    {
                        CurIcon[i].gameObject.SetActive(false);
                    }
                }

                CurPlaySet(true);
                break;
            case 3:
                Destroy(GameObject.Find(DeckData[CurSlot] + "(Clone)"));

                for (int i = CurSlot; i < 4; i++)
                {
                    CurIcon[i].sprite = Resources.Load<Sprite>("CharIcon/" + CurIcon[i + 1]);
                    DeckData[i] = DeckData[i + 1];
                    if (DeckData[i] == "empty")
                    {
                        CurIcon[i].gameObject.SetActive(false);
                    }
                }

                CurPlaySet(true);
                break;
            case 4:
                Destroy(GameObject.Find(DeckData[CurSlot] + "(Clone)"));

                for (int i = CurSlot; i < 4; i++)
                {
                    CurIcon[i].sprite = Resources.Load<Sprite>("CharIcon/" + CurIcon[i + 1]);
                    DeckData[i] = DeckData[i + 1];
                    if (DeckData[i] == "empty")
                    {
                        CurIcon[i].gameObject.SetActive(false);
                    }
                }

                CurPlaySet(true);
                break;
        }
    }

    public void Unit_Info(Job job)
    {
        CurrentJob = job;
        UnitData unit = Dm.GetUnitData(job);
        UnitInfoPanel.SetActive(true);
        UnitInfoImg[0].sprite = Resources.Load<Sprite>("CharImg/" + job);
        UnitInfoImg[1].sprite = Resources.Load<Sprite>("Skill_Img/" + job);
        UnitInfoText[0].text = unit.Name + "\n\n공격력\n\n체력\n\n공격속도";
        UnitInfoText[1].text = "Lv. " + unit.Level + "\n\n" + unit.Atk + "\n\n" + unit.MaxHp + "\n\n" + unit.AtkDelay + " Sec";
        UnitInfoText[2].text = unit.Skill_Tip;
        UnitInfoText[3].text = unit.Piece + " / " + unit.MaxPiece;
        UnitInfoText[4].text = unit.Grade + " -> " + (unit.Grade + 1) + "\nUpgrade";
        UnitPiece.value = unit.Piece / unit.MaxPiece;
    }

    public void UnitLevelUp() // 레벨업 스텟 상승
    {
        UnitData unit = Dm.GetUnitData(CurrentJob);

        if (Dm.GetGold() > NeedGold)
        {
            unit.Level++;
            switch (unit.Grade)
            {
                case 1:
                    unit.Atk += 2;
                    unit.MaxHp += 5;
                    break;
                case 2:
                    unit.Atk += 3;
                    unit.MaxHp += 7;
                    break;
                case 3:
                    unit.Atk += 5;
                    unit.MaxHp += 10;
                    break;
            }
            Unit_Info(CurrentJob);
        }
        else
            StartCoroutine(GoldTextFlash());
    }

    public void GradeUp() // 승급
    {
        UnitData unit = Dm.GetUnitData(CurrentJob);

        if (unit.Piece == unit.MaxPiece && unit.Grade <= 3)
        {
            unit.Grade++;
            Unit_Info(CurrentJob);
        }
        else
            StartCoroutine(CardTextFlash());
    }

    IEnumerator GoldTextFlash()
    {
        float time = 0;
        float duration = 1.5f;

        NeedGoldText.color = Color.red;
        while (time < duration)
        {
            time += Time.deltaTime;
            NeedGoldText.color =
                Color.Lerp(Color.red, FlashColor, time / duration);

            yield return null;
        }
    }

    IEnumerator CardTextFlash()
    {
        float time = 0;
        float duration = 1.5f;

        NeedGoldText.color = Color.red;
        while (time < duration)
        {
            time += Time.deltaTime;
            NeedGoldText.color =
                Color.Lerp(Color.red, FlashColor, time / duration);

            yield return null;
        }
    }

    public void InfoClose()
    {
        UnitInfoPanel.SetActive(false);
    }
}
