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
    DataManager dm;
    private List<string> DeckData = new List<string>();

    int EnemyMaxCount = 15;
    [HideInInspector] public int EnemyCurCount;
    [HideInInspector] public bool StageProgress;

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

    bool StageGettingReady = false;

    [SerializeField] private Text GoldText;
    [SerializeField] private Text DiamondText;

    private void Start()
    {
        dm = DataManager.Instance;
        DeckData = dm.GetDeckData();
        Cc = CurrentCharacter.Instance;

        StageStart();
    }

    private void Update()
    {
        GoldText.text = dm.GetGold().ToString();
        DiamondText.text = dm.GetDiamond().ToString();
        CurEnemyCountText.text = EnemyCurCount.ToString();

        if (StageProgress == false && EnemyCurCount <= 0 && StageGettingReady == false)
        {
            StagePanel("Clear");
        }
    }

    void StageStart()
    {
        StageGettingReady = false;
        StartCoroutine("EnemyRepawn");
    }

    IEnumerator EnemyRepawn() // 몬스터 소환
    {
        CurEnemyCountText.text = EnemyCurCount.ToString();

        CoroutineCheck++;
        if (CoroutineCheck > 1) // 한번만 실행이 되는지 확인 이미 실행중일때 코루틴 종료
        {
            yield break;
        }

        StartCoroutine(ShowStage());

        StageProgress = true; // 소환이 시작됨을 체크

        for (int i = 0; i < EnemyMaxCount; i++) // 스테이지당 몬스터 최대카운트 만큼 소환, 66% Enemy0번소환, 20% Enemy1~5번소환, 14% Enemy6~7번 소환
        {                                       // 약한 순으로 소환 될 확률을 높인다.
            int RandomRepawn = Random.Range(0, EnemyMaxCount);

            if (RandomRepawn >= 0 && RandomRepawn <= EnemyMaxCount / 1.5f)
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
            CurEnemyCountText.text = EnemyCurCount.ToString(); // 소환시 현재 카운트가 상승 화면에 표시 남은 몬스터 수 를 확인
            yield return new WaitForSeconds(Random.Range(1, 1.5f));
        }
        if (dm.GetCurStage() % 5 == 0) // 5라운드마다 보스라운드, 모든 몬스터가 소환된 후 보스 생성
        {
            GameObject EnemyPrefab = Resources.Load<GameObject>("SPUM/SPUM_Units/SPUM_Enemy/" + dm.GetEnemyData((CharacterState.EnemyJob)8).Job);
            GameObject CurEnemy = null;
            CurEnemy = Instantiate(EnemyPrefab, TrEnemy);
            CurEnemy.transform.localPosition = new Vector3(0, 0, 14);
            EnemyCurCount++;
            CurEnemyCountText.text = EnemyCurCount.ToString();
        }
        StageProgress = false; // 소환 종료 체크
    }

    public void HpBarSet(int SlotNum, float curHp, float maxHp, int emptyIndex) // 소환된 유닛의 체력에 변화가 있을 때 값을 받아와 화면에 표시
    {                                                                           // 소환, 소환취소, 피격, 회복 등
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

        if (CurHpSum <= 0) // 전체 체력을 모두 잃었을때 실행
        {                  // 몬스터소환 코루틴 정지, 체력 리셋, 스테이지 클리어실패 패널 함수 실행
            Die = true;
            StopCoroutine("EnemyRepawn");
            CurHpSum = MaxHpSum;
            StagePanel("Fail");
        }
    }

    public void StagePanel(string Type) // 호출 시 들어온 인자를 확인 해 스테이지 클리어, 실패를 확인
    {
        StageGettingReady = true;
        CoroutineCheck = 0;
        StageReset();
        stagePanel.SetActive(true);
        if (dm.GetCurStage() == 1)      // 현재 스테이지가 1스테이지 일 경우 
            StageText[2].text = null;   // 이전 스테이지 텍스트 null
        else
            StageText[2].text = "Stage\n" + (dm.GetCurStage() - 1); // 이전 스테이지
        
        StageText[3].text = "Stage\n" + dm.GetCurStage();           // 현재 스테이지
        StageText[4].text = "Stage\n" + (dm.GetCurStage() + 1);     // 다음 스테이지
        switch (Type)
        {
            case "Fail":                                        // 스테이지 실패 시
                ClearRewardGold.SetActive(false);               // 클리어 보상이 없음
                ClearRewardDia.SetActive(false);
                StageText[0].text = "Stage Fail";
                StageText[1].text = "Back Stage Loading..";
                if (dm.GetCurStage() > 1)                       // 2스테이지 이상부터는 실패 시 이전 스테이지로 돌아감 ( 방치플레이중 계속 실패 방지 )
                    StartCoroutine(Loading("Back"));
                else
                    StartCoroutine(Loading("Current"));

                break;
            case "Clear":                                       // 스테이지 클리어 시
                if (dm.GetMaxStage() < dm.GetCurStage())        // 최대클리어 스테이지를 클리어한 현재 스테이지로 변경
                    dm.SetMaxStage(dm.GetCurStage());

                StageText[0].text = "Stage Clear\n";
                StageText[1].text = "Current Stage Loading..";
                ClearRewardGold.SetActive(true);
                ClearRewardDia.SetActive(true);
                int clearGold = Random.Range(dm.GetCurStage() * 50, dm.GetCurStage() * 60);
                StageText[5].text = clearGold.ToString();
                StageText[6].text = "1";
                dm.SetGold(dm.GetGold() + clearGold);
                dm.SetDiamond(dm.GetDiamond() + 1);

                StartCoroutine(Loading("Current"));             // 클리어 시 기본적으로 현재 스테이지를 무한반복 ( 원하는 스테이지 노가다 )
                break;
        }
    }

    IEnumerator Loading(string stage) // 스테이지 클리어,실패 후 다음 스테이지를 선택하기 전 남은 시간을 보여줄 로딩바
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

    void StageReset() // 클리어 실패 시 남은 몬스터, 필드에 남아있는 스킬등 스테이지 시작 전 모두 리셋
    {
        Transform[] EnemyList = GetComponentsInChildren<Transform>(true);                       // 남아있는 몬스터 체크 후 모두 삭제
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
        
        foreach (string units in UnitList)                                                      // 소환된 유닛들의 체력을 모두 리셋
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

        Transform[] skillList = GameObject.Find("Skill").GetComponentsInChildren<Transform>(true); // 필드에 남아있는 스킬 체크, 삭제
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

    public void StageBtn(string Type) // 이전, 현재, 다음 스테이지 선택
    {
        Die = false;

        var UnitList = DeckData.FindAll(unit => unit != "empty"); // 덱 데이터에서 소환되어있는 유닛정보를 가져와 사망(애니메이션)중인 유닛들을 리셋
        foreach (string units in UnitList)
        {
            UnitFsm unit = GameObject.Find(units + "(Clone)").GetComponent<UnitFsm>();
            unit._prefabs._anim.SetBool("EditChk", true);
            unit._prefabs.PlayAnimation(1);
        }
        switch (Type) // 별다른 선택이 없을 시 현재 스테이지 반복, 현재 스테이지를 클리어 하지 못했을 때 다음 스테이지 선택불가
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

    IEnumerator ShowStage() // 스테이지 시작 시 현재 스테이지 확인용 텍스트
    {
        float speed = 20;
        ShowStageText.gameObject.SetActive(true);
        ShowStageText.text = "Stage " + dm.GetCurStage();
        if (dm.GetCurStage() % 5 == 0)
        {
            ShowStageText.text = "Boss Stage !!";
        }
        ShowStageText.transform.position = new Vector2(1400, 1735);

        while (ShowStageText.transform.position.x >= 540)
        {
            ShowStageText.transform.Translate(Vector2.left * speed);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        ShowStageText.gameObject.SetActive(false);
    }

    public IEnumerator TakeGold(int money)
    {
        yield return new WaitForSeconds(1.5f);
        dm.SetGold(dm.GetGold() + money);
    }
}