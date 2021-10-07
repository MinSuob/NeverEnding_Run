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
        BuffReSet();
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
            if (skillOdds <= unit.SkillOdds)
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
                                if (sm.BuffOn[0] == false)
                                {
                                    sm.addAtk = unit.Atk;
                                    SkillEfect(0, 0.8f);
                                    unit.Atk += sm.addAtk;
                                    if (CurHp < MaxHp)
                                    {
                                        CurHp += MaxHp / 2;
                                        if (CurHp > MaxHp)
                                        {
                                            CurHp = MaxHp;
                                        }
                                        HpSet(CurHp);
                                    }
                                    StartCoroutine(Buff(sm.addAtk, 10, 0));
                                }
                                break;
                            case "궁수":
                                _prefabs.PlayAnimation(8);
                                StartCoroutine(SkillDelay(2, 0.5f, 0, 0));
                                break;
                            case "라이트닝 마법사":
                                _prefabs.PlayAnimation(9);
                                StartCoroutine(SkillDelay(1, 0.5f, 0, 2));
                                break;
                            case "모험가":
                                if (sm.BuffOn[1] == false)
                                {
                                    _prefabs.PlayAnimation(9);
                                    StartCoroutine(Buff(unit.Atk, 5, 1));
                                    allskill.skillon(unit.Skill_Name);
                                }
                                break;
                            case "도적":
                                _prefabs.PlayAnimation(8);
                                StartCoroutine(SkillDelay(2, 0.5f, 0, 0));
                                break;
                            case "방패병":
                                SkillEfect(0, 0.8f);
                                if (CurHp < MaxHp)
                                {
                                    CurHp += unit.Atk * 2;
                                    if (CurHp > MaxHp)
                                    {
                                        CurHp = MaxHp;
                                    }
                                    HpSet(CurHp);
                                }
                                break;
                            case "사냥꾼":
                                _prefabs.PlayAnimation(8);
                                StartCoroutine(SkillDelay(1, 0.5f, 0.5f, 0.8f));
                                break;
                            case "더블액스":
                                _prefabs.PlayAnimation(7);
                                StartCoroutine(SkillDelay(1, 0.3f, enemyFsm.transform.position.x, enemyFsm.transform.position.y + 0.2f));
                                break;
                            case "엘프":
                                _prefabs.PlayAnimation(8);
                                StartCoroutine(SkillDelay(1, 0.5f, 0.5f, 0.8f));
                                break;
                            case "성기사":
                                if (sm.BuffOn[2] == false)
                                {
                                    _prefabs.PlayAnimation(9);
                                    StartCoroutine(Buff(unit.Atk, 5.1f, 2));
                                    allskill.skillon(unit.Skill_Name);
                                }
                                break;
                            case "기사":
                                _prefabs.PlayAnimation(9);
                                SkillEfect(1.5f, 2);
                                break;
                            case "헌터":
                                _prefabs.PlayAnimation(8);
                                StartCoroutine(SkillDelay(1, 0.5f, 1.5f, 4));
                                break;
                            case "포이즌":
                                _prefabs.PlayAnimation(9);
                                StartCoroutine(SkillDelay(3, 0.5f, enemyFsm.transform.position.x, enemyFsm.transform.position.y + 0.5f));
                                break;
                            case "아이스":
                                _prefabs.PlayAnimation(9);
                                StartCoroutine(SkillDelay(1, 0.8f, -0.5f, 0.5f));
                                break;
                            case "파이어":
                                _prefabs.PlayAnimation(9);
                                SkillEfect(1.5f, 7);
                                break;
                            case "라이트닝":
                                _prefabs.PlayAnimation(9);
                                StartCoroutine(SkillDelay(3, 0.5f, enemyFsm.transform.position.x, enemyFsm.transform.position.y));
                                break;
                            case "시프":
                                _prefabs.PlayAnimation(5);
                                StartCoroutine(SkillDelay(1, 0.5f, 0, 0.7f));
                                break;
                            case "탱커":
                                if (sm.BuffOn[4] == false)
                                {
                                    _prefabs.PlayAnimation(9);
                                    StartCoroutine(Buff(unit.Atk, 5.1f, 4));
                                    allskill.skillon(unit.Skill_Name);
                                }
                                break;
                            case "창병":
                                if (sm.BuffOn[5] == false)
                                {
                                    _prefabs.PlayAnimation(9);
                                    sm.addAtk2 = unit.Atk * 2;
                                    StartCoroutine(SkillDelay(1, 0.5f, 0, 0.2f));
                                    unit.Atk += sm.addAtk2;
                                    StartCoroutine(Buff(sm.addAtk2, 10, 5));  
                                }
                                break;
                            case "도살자":
                                _prefabs.PlayAnimation(7);
                                StartCoroutine(SkillDelay(1, 0.3f, enemyFsm.transform.position.x, enemyFsm.transform.position.y + 0.2f));
                                break;
                            case "엘프(남)":
                                _prefabs.PlayAnimation(8);
                                SkillEfect(-1, -4.3f);
                                break;
                            case "성녀":
                                if (sm.BuffOn[3] == false)
                                {
                                    _prefabs.PlayAnimation(9);
                                    StartCoroutine(Buff(unit.Atk, 5.1f, 3));
                                    allskill.skillon(unit.Skill_Name);
                                }
                                break;
                            case "워리어":
                                _prefabs.PlayAnimation(9);
                                StartCoroutine(SkillDelay(1, 0.5f, 1.5f, 2));
                                break;
                            case "거인":
                                _prefabs.PlayAnimation(7);
                                StartCoroutine(SkillDelay(1, 0.3f, enemyFsm.transform.position.x, enemyFsm.transform.position.y + 0.2f));
                                break;
                            case "자이언트":
                                _prefabs.PlayAnimation(7);
                                StartCoroutine(SkillDelay(1, 0.3f, enemyFsm.transform.position.x, enemyFsm.transform.position.y - 0.5f));
                                break;
                            default:
                                _prefabs.PlayAnimation(9);
                                StartCoroutine(SkillDelay(1, 0.5f, enemyFsm.transform.position.x, enemyFsm.transform.position.y));
                                break;
                        }
                        unit.AtkType = atkType;
                    }
                    else
                    {
                        unit.AtkType = atkType;
                        Fight_On = false;
                        yield return new WaitForSeconds(unit.AtkDelay);
                        Box.ReSize();
                    }
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

    IEnumerator SkillDelay(int type, float time, float x, float y)
    {
        switch (type)
        {
            case 1:
                yield return new WaitForSeconds(time);
                SkillEfect(x, y);
                break;
            case 2:
                yield return new WaitForSeconds(time);
                allskill.skillon(unit.Skill_Name);
                break;
            case 3:
                yield return new WaitForSeconds(time);
                SkillEfect(x, y);
                SkillEfect2(x, y);
                break;
            default:
                break;
        }
    }

    public void HpSet(float curHp)
    {
        if (sm.Die == true)
        {
            return;
        }
        MySlotNum = DeckData.FindIndex(num => num.Contains(job.ToString()));

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

    void SkillEfect2(float x, float y)
    {
        var parent = GameObject.Find("Skill");
        GameObject Effect = Resources.Load<GameObject>("Effect/" + unit.Skill_Name2);
        GameObject Pos = Instantiate(Effect, parent.transform);
        Pos.transform.position = new Vector2(x, y);
    }

    IEnumerator Buff(float atk, float time, int num)
    {
        switch (num)
        {
            case 0: // 칼병
                sm.BuffOn[num] = true;
                yield return new WaitForSeconds(time);
                unit.Atk -= atk;
                sm.addAtk = 0;
                sm.BuffOn[num] = false;
                break;
            case 1: // 모험가
                sm.BuffOn[num] = true;
                yield return new WaitForSeconds(time);
                sm.BuffOn[num] = false;
                break;
            case 2: // 성기사
                sm.BuffOn[num] = true;
                yield return new WaitForSeconds(time);
                sm.BuffOn[num] = false;
                break;
            case 3: // 성녀
                sm.BuffOn[num] = true;
                yield return new WaitForSeconds(time);
                sm.BuffOn[num] = false;
                break;
            case 4: // 성기사
                sm.BuffOn[num] = true;
                yield return new WaitForSeconds(time);
                sm.BuffOn[num] = false;
                break;
            case 5: // 창병
                sm.BuffOn[num] = true;
                yield return new WaitForSeconds(time);
                unit.Atk -= atk;
                sm.addAtk2 = 0;
                sm.BuffOn[num] = false;
                break;
        }
    }

    void BuffReSet()
    {
        // 칼병
        if (gameObject.name == "Unit0(Clone)" && sm.addAtk != 0)
        {
            unit.Atk -= sm.addAtk;
            sm.addAtk = 0;
        }
        if (!DeckData.Contains("Unit0") && sm.addAtk != 0)
        {
            Destroy(GameObject.Find("CFX4AuraBubbleC(Clone)"));
            sm.BuffOn[0] = false;
        }

        // 모험가
        if (!GameObject.Find("CFX2_Wandering_Spirits(Clone)"))
        {
            sm.BuffOn[1] = false;
        }

        //성기사
        if (!GameObject.Find("CFX_Magical_Source(Clone)"))
        {
            sm.BuffOn[2] = false;
        }
    }
}