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
    int EnemyMaxCount = 1;
    // Stage Cur Enemy Count
    [HideInInspector] public int EnemyCurCount;
    [HideInInspector] public bool StageProgress;

    // Stage Enemy 스텟 상승률 함수

    // Stage Reward

    [SerializeField] private Transform TrEnemy;
    [SerializeField] private Slider UnitsHpBar;
    [SerializeField] private Text HpText;

    float CurHpSum;
    float MaxHpSum;
    public float[] CurHp;
    public float[] MaxHp;

    // Stage Panel
    [SerializeField] private GameObject stagePanel;
    [SerializeField] private Text[] StageText;
    [SerializeField] private Slider LoadingBar;

    int a = 0;



    private void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();
        Cc = CurrentCharacter.Instance;
        CurStage = DataManager.Instance.GetCurStage();

        //StageStart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(EnemyRepawn());
        }
    }

    void StageStart()
    {
        MaxCountUp();
        StartCoroutine(EnemyRepawn());
    }

    void MaxCountUp()
    {
        if (CurStage >= 100)
        {
            if (CurStage % 100 == 0 && a == CurStage - 100)
            {
                EnemyMaxCount++;
                a += CurStage;
            }
        }
    }

    IEnumerator EnemyRepawn()
    {
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
        CurHpSum = 0;
        MaxHpSum = 0;

        if (emptyIndex != -1)
        {
            CurHp[emptyIndex] = 0;
            MaxHp[emptyIndex] = 0;
        }

        if (CurHp[SlotNum] != MaxHp[SlotNum] && curHp == maxHp)
        {
            MaxHp[SlotNum] = maxHp;
        }
        else
        {
            CurHp[SlotNum] = curHp;

            MaxHp[SlotNum] = maxHp;
        }

        GameObject.Find(DeckData[SlotNum] + "(Clone)").GetComponent<UnitFsm>().CurHp = CurHp[SlotNum];

        for (int i = 0; i < 5; i++)
        {
            CurHpSum += CurHp[i];
            MaxHpSum += MaxHp[i];
        }

        UnitsHpBar.value = CurHpSum / MaxHpSum;
        HpText.text = CurHpSum + " / " + MaxHpSum;

        if (CurHpSum <= 0)
        {
            var UnitList = DeckData.FindAll(unit => unit != "empty");

            foreach (string units in UnitList)
            {
                UnitFsm unit = GameObject.Find(units + "(Clone)").GetComponent<UnitFsm>();
                unit._prefabs.PlayAnimation(2);
            }
            StagePanel("Fail");
        }
    }

    public void StagePanel(string Type)
    {
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

        var UnitList = DeckData.FindAll(unit => unit != "empty");

        foreach (string units in UnitList)
        {
            UnitFsm unit = GameObject.Find(units + "(Clone)").GetComponent<UnitFsm>();
            unit.CurHp = unit.MaxHp;
        }

        EnemyCurCount = 0;
    }

    public void StageBtn(string Type)
    {
        switch (Type)
        {
            case "Back":

                break;
            case "Current":
                StageReset();
                stagePanel.SetActive(false);
                EnemyRepawn();
                break;
            case "Next":

                break;
        }
    }
}