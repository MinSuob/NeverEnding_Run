using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class UnitFsm : MonoBehaviour
{
    public Job job;
    [HideInInspector] public SPUM_Prefabs _prefabs;
    [HideInInspector] public UnitData unit;

    public bool Fight_On = false;
    [HideInInspector] public UnitDistanceBox Box;

    private List<string> DeckData = new List<string>();
    StageManager sm;

    int MySlotNum;

    [HideInInspector] public float MaxHp;
    [HideInInspector] public float CurHp;
    bool[] BuffOn = {false,false};

    AllAttackSkill allskill;

    private void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();
        _prefabs = gameObject.GetComponent<SPUM_Prefabs>();
         unit = DataManager.Instance.GetUnitData(job);
        Box = gameObject.transform.GetChild(2).gameObject.GetComponent<UnitDistanceBox>();
        allskill = GameObject.Find("Full").GetComponent<AllAttackSkill>();
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();

        MaxHp = unit.MaxHp;
        CurHp = unit.CurHp;
        
        HpSet(CurHp);
    }

    private void Update()
    {

    }

    public IEnumerator Attack(Collider2D Enemy)
    {
        if (sm.Die == true)
        {
            yield break;
        }
        EnemyFsm enemyFsm = Enemy.GetComponent<EnemyFsm>();
        string atkType = unit.AtkType;
        while (Fight_On)
        {
            int skillOdds = Random.Range(1, 101);
            if (skillOdds <= 100)
                unit.AtkType = "Skill";

            switch (unit.AtkType)
            {
                case "Melee":
                    if (Enemy != null)
                    {
                        _prefabs.PlayAnimation(4);
                        enemyFsm.Damage(unit.Atk, 0.2f);
                        HitEffect(enemyFsm.transform);
                        if (enemyFsm.CurHp <= 0)
                        {
                            yield return new WaitForSeconds(unit.AtkDelay);
                            Fight_On = false;
                            Box.ReSize();
                        }
                    }
                    else
                    {
                        Fight_On = false;
                        Box.ReSize();
                    }
                    break;
                case "Bow":
                    if (Enemy != null)
                    {
                        _prefabs.PlayAnimation(5);
                        enemyFsm.Damage(unit.Atk, 0.5f);
                        StartCoroutine(EffectDelay(enemyFsm.transform));
                        if (enemyFsm.CurHp <= 0)
                        {
                            yield return new WaitForSeconds(unit.AtkDelay);
                            Fight_On = false;
                            Box.ReSize();
                        }
                    }
                    else
                    {
                        Fight_On = false;
                        Box.ReSize();
                    }
                    break;
                case "Magic":
                    if (Enemy != null)
                    {
                        _prefabs.PlayAnimation(6);
                        enemyFsm.Damage(unit.Atk, 0.2f);
                        HitEffect(enemyFsm.transform);
                        if (enemyFsm.CurHp <= 0)
                        {
                            yield return new WaitForSeconds(unit.AtkDelay);
                            Fight_On = false;
                            Box.ReSize();
                        }
                    }
                    else
                    {
                        Fight_On = false;
                        Box.ReSize();
                    }
                    break;
                case "Skill":
                    

                    if (enemyFsm != null)
                    {
                        switch (unit.Name)
                        {
                            case "칼병":
                                if (BuffOn[0] == false)
                                {
                                    SkillEfect(0, 0.8f);
                                    unit.Atk += unit.Atk;
                                    if (CurHp < MaxHp)
                                    {
                                        CurHp += CurHp / 2;
                                        HpSet(CurHp);
                                    }
                                    StartCoroutine(Buff(unit.Atk, 10, 0));
                                }
                                unit.AtkType = atkType;
                                break;
                            case "궁수":
                                allskill.skillon(unit.Skill_Name);
                                break;
                            case "라이트닝 마법사":
                                SkillEfect(0, 2);
                                break;
                            case "모험가":
                                if (BuffOn[1] == false)
                                {
                                    StartCoroutine(Buff(unit.Atk, 5, 1));
                                    allskill.skillon(unit.Skill_Name);
                                }
                                break;
                            case "도적":
                                allskill.skillon(unit.Skill_Name);
                                break;
                            case "탱커":
                                SkillEfect(0, 0.8f);
                                break;
                            case "창병":
                                SkillEfect(0.5f, 0.8f);
                                break;
                            case "더블액스":
                                SkillEfect(enemyFsm.transform.position.x, enemyFsm.transform.position.y + 0.2f);
                                break;
                            case "엘프":
                                SkillEfect(0.5f, 0.8f);
                                break;
                            case "성기사":
                                SkillEfect(0, 2);
                                break;
                            default:
                                SkillEfect(enemyFsm.transform.position.x, enemyFsm.transform.position.y + 0.2f);
                                break;
                        }
                        unit.AtkType = atkType;
                    }
                    else
                        break;
                    break;
            }
            yield return new WaitForSeconds(unit.AtkDelay);
        }
    }

    void HitEffect(Transform pos)
    {
        var parent = GameObject.Find("Hit");
        
        GameObject Effect = Resources.Load<GameObject>("Effect/Hit/" + unit.AtkName);
        GameObject Pos = Instantiate(Effect, parent.transform);
        if (pos != null)
        {
            Pos.transform.position = new Vector2(pos.transform.position.x, pos.transform.position.y + 0.2f);
        }
        else
            return;
    }

    IEnumerator EffectDelay(Transform pos)
    {
        var parent = GameObject.Find("Hit");
        
        yield return new WaitForSeconds(0.5f);
        GameObject Effect = Resources.Load<GameObject>("Effect/Hit/" + unit.AtkName);
        GameObject Pos = Instantiate(Effect, parent.transform);
        if (pos != null)
        {
            Pos.transform.position = new Vector2(pos.transform.position.x, pos.transform.position.y + 0.2f);
        }
        else
            yield break;
    }

    public void HpSet(float curHp)
    {
        if (sm.Die == true)
        {
            return;
        }
        MySlotNum = DeckData.FindIndex(num => num.Contains(job.ToString()));

        //if (MySlotNum == 0 && sm.CurHp[0] != sm.MaxHp[0])
        //{
        //    CurHp = sm.CurHp[0];
        //}

        sm.HpBarSet(MySlotNum, curHp, unit.MaxHp, DeckData.FindIndex(num => num.Contains("empty")));
    }

    public void Damage(float damage, float Delay)
    {
        CurHp -= damage;
        StartCoroutine(DamageDelay(Delay));
    }

    IEnumerator DamageDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HpSet(CurHp);
    }

    void SkillEfect(float x, float y)
    {
        var parent = GameObject.Find("Skill");
        GameObject Effect = Resources.Load<GameObject>("Effect/" + unit.Skill_Name);
        GameObject Pos = Instantiate(Effect, parent.transform);
        Pos.transform.position = new Vector2(x, y);
    }

    IEnumerator Buff(float atk, float time,int num)
    {
        switch (num)
        {
            case 0: // 칼병
                BuffOn[num] = true;
                yield return new WaitForSeconds(time);
                unit.Atk -= atk;
                BuffOn[num] = false;
                break;
            case 1: // 모험가
                BuffOn[num] = true;
                int timecount = 0;
                UnitFsm Unit = GameObject.Find(DeckData[0] + "(Clone)").GetComponent<UnitFsm>();
                while (BuffOn[num] == true && timecount < time)
                {
                    if (Unit.CurHp < Unit.MaxHp)
                    {
                        Unit.CurHp += atk;
                        Unit.HpSet(Unit.CurHp);
                    }
                    yield return new WaitForSeconds(1);
                    timecount++;
                }
                BuffOn[num] = false;
                break;
        }
        
    }
}
