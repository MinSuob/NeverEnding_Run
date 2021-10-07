using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;

public class ManagerEtc : MonoBehaviour
{
    DataManager dm;
    CurrentCharacter cc;

    public GameObject UnitPanel;
    public GameObject ShopPanel;
    public GameObject OpenPanel;
    public GameObject cardPrefab;
    public Transform cardSlot;

    private void Start()
    {
        dm = DataManager.Instance;
        cc = CurrentCharacter.Instance;
    }

    public void MenuBtn(string name)
    {
        switch (name)
        {
            case "Unit":
                UnitPanel.SetActive(true);
                ShopPanel.SetActive(false);
                break;
            case "Shop":
                ShopPanel.SetActive(true);
                UnitPanel.SetActive(false);
                break;
        }
    }

    public void CardPack(string name)
    {
        if (name == "Bronze")
        {
            for (int i = 0; i < 13; i++)
            {
                if (dm.GetUnitData((Job)i).Piece != 20)
                    break;

                if (i == 12)
                {
                    if (dm.GetUnitData((Job)i).Piece == 20)
                    {
                        cc.StartCoroutine(cc.ShowErrorText("뽑을 수 있는 카드가 없습니다."));
                        return;
                    }
                }
            }
        }
        if (name == "Silver")
        {
            for (int i = 13; i < 25; i++)
            {
                if (dm.GetUnitData((Job)i).Piece != 20)
                    break;

                if (i == 24)
                {
                    if (dm.GetUnitData((Job)i).Piece == 20)
                    {
                        cc.StartCoroutine(cc.ShowErrorText("뽑을 수 있는 카드가 없습니다."));
                        return;
                    }
                }
            }
        }
        if (name == "Gold")
        {
            for (int i = 25; i < 28; i++)
            {
                if (dm.GetUnitData((Job)i).Piece != 20)
                    break;

                if (i == 27)
                {
                    if (dm.GetUnitData((Job)i).Piece == 20)
                    {
                        cc.StartCoroutine(cc.ShowErrorText("뽑을 수 있는 카드가 없습니다."));
                        return;
                    }
                }
            }
        }
        StartCoroutine(CardOpen(name));
    }

    IEnumerator CardOpen(string name)
    {
        OpenPanel.SetActive(true);

        switch (name)
        {
            case "Bronze":
                for (int i = 0; i < 20; i++)
                {
                    int rand = UnityEngine.Random.Range(0, 13);
                    if (dm.GetUnitData((Job)rand).Piece < 20)
                    {
                        dm.GetUnitData((Job)rand).Piece++;
                        GameObject ShowChar = null;
                        ShowChar = Instantiate(cardPrefab, cardSlot);
                        ShowChar.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("CharImg/" + (Job)rand);
                        yield return new WaitForSeconds(0.01f);
                    }
                    else
                    {
                        for (int j = 0; j < 13; j++)
                        {
                            if (dm.GetUnitData((Job)j).Piece != 20)
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }
                break;
            case "Silver":
                for (int i = 0; i < 10; i++)
                {
                    int rand = UnityEngine.Random.Range(13, 25);
                    if (dm.GetUnitData((Job)rand).Piece < 20)
                    {
                        dm.GetUnitData((Job)rand).Piece++;
                        GameObject ShowChar = null;
                        ShowChar = Instantiate(cardPrefab, cardSlot);
                        ShowChar.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("CharImg/" + (Job)rand);
                        yield return new WaitForSeconds(0.01f);
                    }
                    else
                    {
                        for (int j = 13; j < 25; j++)
                        {
                            if (dm.GetUnitData((Job)j).Piece != 20)
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }
                break;
            case "Gold":
                for (int i = 0; i < 5; i++)
                {
                    int rand = UnityEngine.Random.Range(25, 28);
                    if (dm.GetUnitData((Job)rand).Piece < 20)
                    {
                        dm.GetUnitData((Job)rand).Piece++;
                        GameObject ShowChar = null;
                        ShowChar = Instantiate(cardPrefab, cardSlot);
                        ShowChar.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("CharImg/" + (Job)rand);
                        yield return new WaitForSeconds(0.01f);
                    }
                    else
                    {
                        for (int j = 25; j < 28; j++)
                        {
                            if (dm.GetUnitData((Job)j).Piece != 20)
                            {
                                i--;
                                break;
                            }
                        }
                    }
                }
                break;
        }
    }

    public void CardClose()
    {
        OpenPanel.SetActive(false);

        for (int i = 0; i < cardSlot.transform.childCount; i++)
        {
            Destroy(cardSlot.transform.GetChild(i).gameObject);
        }
    }
}
