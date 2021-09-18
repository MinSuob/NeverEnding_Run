﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    #region Singleton
    private static StageManager instance;
    public static StageManager Instance
    {
        get { return instance; }
    }
    #endregion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    CurrentCharacter Cc;
    DataManager dm;
    private List<string> DeckData = new List<string>();

    // Stage Max Enemy Count
    int EnemyMaxCount = 15;
    // Stage Cur Enemy Count
    [HideInInspector] public int EnemyCurCount;
    [HideInInspector] public bool StageProgress;

    // Stage Enemy 스텟 상승률 함수

    // Stage Reward

    [SerializeField] private Transform TrEnemy;
    [SerializeField] private Slider UnitsHpBar;
    [SerializeField] private Text HpText;

    [HideInInspector] public float CurHpSum;
    float MaxHpSum;
    public float[] CurHp;
    public float[] MaxHp;
    string beforeUnit;

    // Stage Panel
    [SerializeField] private GameObject stagePanel;
    [SerializeField] private Text[] StageText;
    [SerializeField] private Slider LoadingBar;
    public Text ShowStageText;
    [SerializeField] public Text CurEnemyCountText;

    int CoroutineCheck = 0;
    [HideInInspector] public bool Die;

    [HideInInspector] public bool StageClear;

    public bool[] BuffOn;
    [HideInInspector] public float addAtk = 0;
    [HideInInspector] public float addAtk2 = 0;

    [SerializeField] GameObject ClearRewardGold;
    [SerializeField] GameObject ClearRewardDia;

    private void Start()
    {
        dm = DataManager.Instance;
        DeckData = dm.GetDeckData();
        Cc = CurrentCharacter.Instance;

        StageStart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("EnemyRepawn");
        }
        
    }

    void StageStart()
    {
        StartCoroutine("EnemyRepawn");
    }

    IEnumerator EnemyRepawn()
    {
        CurEnemyCountText.text = EnemyCurCount.ToString();
        CoroutineCheck++;
        if (CoroutineCheck > 1)
        {
            yield break;
        }

        StartCoroutine(ShowStage());

        StageProgress = true;

        for (int i = 0; i < EnemyMaxCount; i++)
        {
            int RandomRepawn = Random.Range(0, EnemyMaxCount);

            if (RandomRepawn >= 0 && RandomRepawn <= EnemyMaxCount / 1.5)
            {
                GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData(0).Job);
                GameObject CurEnemy = null;
                CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
                CurEnemy.transform.localPosition = new Vector3(0, Random.Range(-0.4f, 0.35f), 11);
            }
            if (RandomRepawn > EnemyMaxCount / 1.5 && RandomRepawn <= EnemyMaxCount / 1.1f)
            {
                GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData((CharacterState.EnemyJob)Random.Range(1, 6)).Job);
                GameObject CurEnemy = null;
                CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
                CurEnemy.transform.localPosition = new Vector3(0, Random.Range(-0.4f, 0.35f), 12);
            }
            if (RandomRepawn > EnemyMaxCount / 1.1f && RandomRepawn <= EnemyMaxCount)
            {
                GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData((CharacterState.EnemyJob)Random.Range(6, 8)).Job);
                GameObject CurEnemy = null;
                CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
                CurEnemy.transform.localPosition = new Vector3(0, Random.Range(-0.4f, 0.35f), 13);
            }
            EnemyCurCount++;
            CurEnemyCountText.text = EnemyCurCount.ToString();
            yield return new WaitForSeconds(Random.Range(1, 1.5f));
        }
        if (dm.GetCurStage() % 5 == 0)
        {
            GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData((CharacterState.EnemyJob)8).Job);
            GameObject CurEnemy = null;
            CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
            CurEnemy.transform.localPosition = new Vector2(0, 0);
        }
        StageProgress = false;
    }

    public void HpBarSet(int SlotNum, float curHp, float maxHp, int emptyIndex)
    {
        if (emptyIndex != -1)
        {
            //if (CurHp[0] != MaxHp[0])
            //{
            //    CurHp[0] -= CurHp[emptyIndex];

            //}
            CurHp[emptyIndex] = 0;
            MaxHp[emptyIndex] = 0;
        }

        CurHpSum = 0;
        MaxHpSum = 0;

        var unit = GameObject.Find(DeckData[0] + "(Clone)").GetComponent<UnitFsm>();
        

        if (SlotNum == 0)                   // 0번 슬롯
        {
            if (CurHp[0] == MaxHp[0])       // 피가 닳지 않았을 때
            {
                CurHp[0] = curHp;
                MaxHp[0] = maxHp;
            }
            else                            // 피가 닳아 있을 때
            {
                
                if (curHp > CurHp[0])       // 들어오는 유닛의 체력이 현재 체력보다 높을 시
                {
                    if (unit.name == beforeUnit) // 교체 x 회복 o
                    {
                        CurHp[0] = curHp;
                    }
                    else
                    {
                        MaxHp[0] = maxHp;       // 현재 체력 유지, 최대체력 갖고오기
                        unit.CurHp = CurHp[0];  // 들어온 유닛에게 현재체력 보내주기
                    }
                }
                else                        // 들어오는 유닛의 체력이 현재 체력보다 낮을 시
                {
                    CurHp[0] = curHp;       // 현재체력을 들어온 유닛의 체력으로 넣어주기
                    MaxHp[0] = maxHp;       // 최대체력 갖고 오기
                }
            }


        }
        else                                // 1 ~ 4번 슬롯
        {
            if (CurHp[0] == MaxHp[0])       // 피가 닳지 않았을 때
            {
                CurHp[SlotNum] = maxHp;
                MaxHp[SlotNum] = maxHp;
            }
            else                            // 피가 닳아 있을 때
            {
                MaxHp[SlotNum] = maxHp;
            }
        }

        beforeUnit = unit.name;

        for (int i = 0; i < 5; i++)
        {
            CurHpSum += CurHp[i];
            MaxHpSum += MaxHp[i];
        }

        UnitsHpBar.value = CurHpSum / MaxHpSum;
        HpText.text = CurHpSum + " / " + MaxHpSum;

        if (CurHpSum <= 0)
        {
            Die = true;
            StopCoroutine("EnemyRepawn");
            CurHpSum = MaxHpSum;
            StagePanel("Fail");
        }
    }

    public void StagePanel(string Type)
    {
        CoroutineCheck = 0;
        StageReset();
        stagePanel.SetActive(true);
        if (dm.GetCurStage() == 1)
            StageText[2].text = null;
        else
            StageText[2].text = "Stage\n" + (dm.GetCurStage() - 1);
        
        StageText[3].text = "Stage\n" + dm.GetCurStage();
        StageText[4].text = "Stage\n" + (dm.GetCurStage() + 1);
        switch (Type)
        {
            case "Fail":
                ClearRewardGold.SetActive(false);
                ClearRewardDia.SetActive(false);
                StageText[0].text = "Stage Fail";
                StageText[1].text = "Back Stage Loading..";
                if (dm.GetCurStage() > 1)
                    StartCoroutine(Loading("Back"));
                else
                    StartCoroutine(Loading("Current"));

                break;
            case "Clear":
                if (dm.GetMaxStage() < dm.GetCurStage())
                    dm.SetMaxStage(dm.GetCurStage());

                StageText[0].text = "Stage Clear\n";
                StageText[1].text = "Current Stage Loading..";
                ClearRewardGold.SetActive(true);
                ClearRewardDia.SetActive(true);
                StageText[5].text = ""; // 클리어보상 골드
                StageText[6].text = ""; // 클리어보상 다이아 ( 현재 스테이지 첫클리어 100? 10? )


                StartCoroutine(Loading("Current"));
                break;
        }
    }

    IEnumerator Loading(string stage)
    {
        LoadingBar.value = 0;

        while (LoadingBar.value < 1f)
        {
            LoadingBar.value += Time.deltaTime / 4f;
            yield return null;
        }

        if (CoroutineCheck == 0)
        {
            StageBtn(stage);
        }
    }

    void StageReset()
    {
        Transform[] EnemyList = GetComponentsInChildren<Transform>(true);                       // 적 삭제
        if (EnemyList != null)
        {
            for (int i = 1; i < EnemyList.Length; i++)
            {
                if (EnemyList[i].name != "DropGold(Clone)")
                {
                    Destroy(EnemyList[i].gameObject);
                }
            }
        }

        EnemyCurCount = 0;

        var UnitList = DeckData.FindAll(unit => unit != "empty");
        
        foreach (string units in UnitList)                                                      // 유닛 초기화
        {
            UnitFsm unit = GameObject.Find(units + "(Clone)").GetComponent<UnitFsm>();
            unit.CurHp = unit.MaxHp;
            if (Die == true)
            {
                unit._prefabs.PlayAnimation(2);
            }
            unit.Fight_On = false;
            unit.Box.ReSize();
        }

        Transform[] skillList = GameObject.Find("Skill").GetComponentsInChildren<Transform>(true);
        if (skillList != null)
        {
            for (int i = 1; i < skillList.Length; i++)
            {
                Destroy(skillList[i].gameObject);
            }
        }

        CurHp[0] = MaxHp[0];
        UnitsHpBar.value = MaxHpSum / MaxHpSum;
        HpText.text = MaxHpSum + " / " + MaxHpSum;
    }

    public void StageBtn(string Type)
    {
        Die = false;

        var UnitList = DeckData.FindAll(unit => unit != "empty");
        foreach (string units in UnitList)
        {
            UnitFsm unit = GameObject.Find(units + "(Clone)").GetComponent<UnitFsm>();
            unit._prefabs._anim.SetBool("EditChk", true);
            unit._prefabs.PlayAnimation(1);
        }
        switch (Type)
        {
            case "Back":
                if (dm.GetCurStage() > 1)
                    dm.SetCurStage(dm.GetCurStage() - 1);
                else
                    Cc.StartCoroutine(Cc.ShowErrorText("첫 스테이지 입니다."));

                stagePanel.SetActive(false);
                StageStart();
                break;
            case "Current":
                stagePanel.SetActive(false);
                StageStart();
                break;
            case "Next":
                if (dm.GetMaxStage() >= dm.GetCurStage())
                    dm.SetCurStage(dm.GetCurStage() + 1);
                else
                    Cc.StartCoroutine(Cc.ShowErrorText("이전 스테이지를 먼저 클리어 해야합니다."));

                stagePanel.SetActive(false);
                StageStart();
                break;
        }
    }

    IEnumerator ShowStage()
    {
        float speed = 20;
        ShowStageText.gameObject.SetActive(true);
        ShowStageText.text = "Stage " + dm.GetCurStage();
        ShowStageText.transform.position = new Vector2(1400, 1735);

        while (ShowStageText.transform.position.x >= 540)
        {
            ShowStageText.transform.Translate(Vector2.left * speed);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        ShowStageText.gameObject.SetActive(false);
    }
}