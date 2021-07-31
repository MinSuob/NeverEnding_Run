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

    public GameObject ChoicePanel;

    private List<string> DeckData = new List<string>();

    private int CurSlot;

    [SerializeField] private Transform CurChars;

    private float xPos = 0;

    [SerializeField] private Image[] CurIcon;
    private int IconNum = 0;
    private int IconDel = 0;
    [SerializeField] private GameObject IconSlot;

    void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();

        CurPlaySet(false);
    }

    void CurPlaySet(bool Remove)
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
                    ChoicePanel.SetActive(false);
                    break;
                }
                CurSlot = Num;
                break;
            case 3:
                if (DeckData[2] == "empty")
                {
                    ChoicePanel.SetActive(false);
                    break;
                }
                CurSlot = Num;
                break;
            case 4:
                if (DeckData[3] == "empty")
                {
                    ChoicePanel.SetActive(false);
                    break;
                }
                CurSlot = Num;
                break;
        }
    }
    public void ChoiceChar(Job job)
    {
        if (DeckData.Contains(job.ToString()))
        {
            // 이미 유닛이 존재
        }
        else
        {
            Destroy(GameObject.Find(DeckData[CurSlot] + "(Clone)"));
            DeckData[CurSlot] = job.ToString();
            CurPlaySet(false);
        }
        ChoicePanel.SetActive(false);
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
}
