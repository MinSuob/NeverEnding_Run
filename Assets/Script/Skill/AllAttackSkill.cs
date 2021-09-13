using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class AllAttackSkill : MonoBehaviour
{
    bool SkillOn = false;
    bool SkillOn1 = false;
    bool SkillOn2 = false;
    bool SkillOn3 = false;
    string SkillName;
    private List<string> DeckData = new List<string>();

    private void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();
    }

    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            switch (SkillName)
            {
                case "CFX4MagicHit": // 궁수
                    if (enemy != null)
                    {
                        GameObject Effect = Resources.Load<GameObject>("Effect/" + SkillName);
                        GameObject Pos = Instantiate(Effect, transform.parent.GetChild(1).transform);
                        Pos.transform.position = enemy.transform.position;
                        StartCoroutine(Damage(enemy, Pos, "궁수", 0));
                        transform.position = new Vector2(-5f, -1.12f);
                    }
                    break;
                case "CFX2_Wandering_Spirits": // 모험가
                    if (enemy != null && SkillOn == false)
                    {
                        SkillOn = true;
                        GameObject Effect1 = Resources.Load<GameObject>("Effect/" + SkillName);
                        GameObject Pos1 = Instantiate(Effect1, transform.parent.GetChild(1).transform);
                        Pos1.transform.position = new Vector2(0, 0);
                        StartCoroutine(Damage(enemy, Pos1,"모험가", 0));
                        transform.position = new Vector2(-5f, -1.12f);
                    }
                    break;
                case "CFX2_Blood": // 도적
                    if (enemy != null)
                    {
                        GameObject Effect2 = Resources.Load<GameObject>("Effect/" + SkillName);
                        GameObject Pos2 = Instantiate(Effect2, transform.parent.GetChild(1).transform);
                        Pos2.transform.position = enemy.transform.position;
                        enemy.Damage(GameObject.Find("Unit7(Clone)").GetComponent<UnitFsm>().unit.Atk * 0.5f, 0);
                        transform.position = new Vector2(-5f, -1.12f);
                    }
                    break;
                case "CFX_Magical_Source": // 성기사
                    if (enemy != null && SkillOn1 == false)
                    {
                        SkillOn1 = true;
                        GameObject Effect3 = Resources.Load<GameObject>("Effect/" + SkillName);
                        GameObject Pos3 = Instantiate(Effect3, transform.parent.GetChild(1).transform);
                        Pos3.transform.position = new Vector2(0, 2);
                        StartCoroutine(Damage(enemy, Pos3, "성기사", 0));
                        transform.position = new Vector2(-5f, -1.12f);
                    }
                    break;
                case "YellowFairyDust": // 성녀
                    if (enemy != null && SkillOn2 == false)
                    {
                        SkillOn2 = true;
                        GameObject Effect4 = Resources.Load<GameObject>("Effect/" + SkillName);
                        GameObject Pos4 = Instantiate(Effect4, transform.parent.GetChild(1).transform);
                        Pos4.transform.position = new Vector2(0, 2);
                        StartCoroutine(Damage(enemy, Pos4, "성녀", 0));
                        transform.position = new Vector2(-5f, -1.12f);
                    }
                    break;
                case "Butterfly": // 탱커
                    if (enemy != null && SkillOn3 == false)
                    {
                        SkillOn3 = true;
                        GameObject Effect5 = Resources.Load<GameObject>("Effect/" + SkillName);
                        GameObject Pos5 = Instantiate(Effect5, transform.parent.GetChild(1).transform);
                        Pos5.transform.position = new Vector2(0, 1.2f);
                        StartCoroutine(Damage(enemy, Pos5, "탱커", 0));
                        transform.position = new Vector2(-5f, -1.12f);
                    }
                    break;
            }
        }
    }

    IEnumerator Damage(EnemyFsm enemy, GameObject prefab,string job ,float delay)
    {
        switch (job)
        {
            case "궁수":
                enemy.Damage(GameObject.Find("Unit1(Clone)").GetComponent<UnitFsm>().unit.Atk * 0.8f, 0);
                yield return new WaitForSeconds(0.3f);
                Destroy(prefab);
                break;
            case "모험가":
                float atk = GameObject.Find("Unit6(Clone)").GetComponent<UnitFsm>().unit.Atk;
                int TimeCount = 0;
                while (TimeCount < 5)
                {
                    UnitFsm Unit = GameObject.Find(DeckData[0] + "(Clone)").GetComponent<UnitFsm>();
                    if (Unit.CurHp < Unit.MaxHp)
                    {
                        Unit.CurHp += Unit.MaxHp * 0.1f; // 0번슬롯 전체체력의 10%만큼 회복
                        if (Unit.CurHp > Unit.MaxHp)
                        {
                            Unit.CurHp = Unit.MaxHp;
                        }
                        Unit.HpSet(Unit.CurHp);
                    }
                    if (enemy != null)
                    {
                        enemy.Damage(atk / 2, 0);
                    }
                    yield return new WaitForSeconds(1);
                    TimeCount++;
                }
                Destroy(prefab);
                SkillOn = false;
                break;
            case "성기사":
                float atk1 = GameObject.Find("Unit12(Clone)").GetComponent<UnitFsm>().unit.Atk;
                int TimeCount1 = 0;
                while (TimeCount1 < 5)
                {
                    UnitFsm Unit = GameObject.Find(DeckData[0] + "(Clone)").GetComponent<UnitFsm>();
                    if (Unit.CurHp < Unit.MaxHp)
                    {
                        Unit.CurHp += (Unit.MaxHp * 0.2f) + atk1; // 0번슬롯 전체체력의 20% + 성기사 공격력만큼 회복
                        if (Unit.CurHp > Unit.MaxHp)
                        {
                            Unit.CurHp = Unit.MaxHp;
                        }
                        Unit.HpSet(Unit.CurHp);
                    }
                    yield return new WaitForSeconds(1);
                    TimeCount1++;
                }
                Destroy(prefab);
                SkillOn1 = false;
                break;
            case "성녀":
                float atk2 = GameObject.Find("Unit24(Clone)").GetComponent<UnitFsm>().unit.Atk;
                int TimeCount2 = 0;
                while (TimeCount2 < 5)
                {
                    UnitFsm Unit = GameObject.Find(DeckData[0] + "(Clone)").GetComponent<UnitFsm>();
                    if (Unit.CurHp < Unit.MaxHp)
                    {
                        Unit.CurHp += atk2 * 2; //성녀 공격력 200% 만큼 회복
                        if (Unit.CurHp > Unit.MaxHp)
                        {
                            Unit.CurHp = Unit.MaxHp;
                        }
                        Unit.HpSet(Unit.CurHp);
                    }
                    yield return new WaitForSeconds(1);
                    TimeCount2++;
                }
                Destroy(prefab);
                SkillOn2 = false;
                break;
            case "탱커":
                int TimeCount3 = 0;
                while (TimeCount3 < 5)
                {
                    UnitFsm Unit = GameObject.Find(DeckData[0] + "(Clone)").GetComponent<UnitFsm>();
                    var TankerAtk = DataManager.Instance.GetUnitData(Job.Unit17).Atk;
                    if (Unit.CurHp < Unit.MaxHp)
                    {
                        Unit.CurHp += TankerAtk * 1.5f; // 0번슬롯 공격력 150%
                        if (Unit.CurHp > Unit.MaxHp)
                        {
                            Unit.CurHp = Unit.MaxHp;
                        }
                        Unit.HpSet(Unit.CurHp);
                    }
                    yield return new WaitForSeconds(1);
                    TimeCount3++;
                }
                Destroy(prefab);
                SkillOn3 = false;
                break;
        }
    }

    public void skillon(string skillname)
    {
        SkillName = skillname;
        transform.position = new Vector2(1.32f, 0.5f);
    }
}
