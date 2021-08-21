using System.Collections;
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
    private List<string> DeckData = new List<string>();

    // Stage Num
    int CurStage;

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

    int StageCheck = 0;
    int CoroutineCheck = 0;
    [HideInInspector] public bool Die;

    [HideInInspector] public bool StageClear;

    private void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();
        Cc = CurrentCharacter.Instance;
        CurStage = DataManager.Instance.GetCurStage();

        StageStart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("EnemyRepawn");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            //Cc.Unit_Info();
        }
    }

    void StageStart()
    {
        MaxCountUp();
        
    }

    void MaxCountUp()
    {
        if (CurStage >= 100)
        {
            if (CurStage % 100 == 0 && StageCheck == CurStage - 100)
            {
                EnemyMaxCount++;
                StageCheck += CurStage;
            }
        }
    }

    IEnumerator EnemyRepawn()
    {
        CoroutineCheck++;
        if (CoroutineCheck > 1)
        {
            yield break;
        }

        StageProgress = true;

        DataManager dm = DataManager.Instance;

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
            yield return new WaitForSeconds(Random.Range(1, 1.5f));
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
                        CurHp[0] = MaxHp[0];

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
        StageReset();
        stagePanel.SetActive(true);

        switch (Type)
        {
            case "Fail":
                StageText[0].text = "Stage Fail";
                StageText[1].text = "Back Stage Loading..";
                CurStage--;
                StartCoroutine(Loading());

                break;
            case "Clear":
                StageText[0].text = "Stage Clear";
                StageText[1].text = "Current Stage Loading..";
                StartCoroutine(Loading());
                break;
        }
    }

    IEnumerator Loading()
    {
        LoadingBar.value = 0;

        while (LoadingBar.value < 1f)
        {
            LoadingBar.value += Time.deltaTime / 4f;
            yield return null;
        }

        StageBtn("Current");
    }

    void StageReset()
    {
        Transform[] EnemyList = GetComponentsInChildren<Transform>(true);
        if (EnemyList != null)
        {
            for (int i = 1; i < EnemyList.Length; i++)
            {
                Destroy(EnemyList[i].gameObject);
            }
        }

        EnemyCurCount = 0;

        var UnitList = DeckData.FindAll(unit => unit != "empty");
        
        foreach (string units in UnitList)
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

        CurHp[0] = MaxHp[0];
        UnitsHpBar.value = MaxHpSum / MaxHpSum;
        HpText.text = MaxHpSum + " / " + MaxHpSum;
    }

    public void StageBtn(string Type)
    {
        Die = false;
        CoroutineCheck = 0;

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

                break;
            case "Current":
                stagePanel.SetActive(false);
                StartCoroutine("EnemyRepawn");
                break;
            case "Next":

                break;
        }
    }
}