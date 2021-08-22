using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAttackSkill : MonoBehaviour
{
    bool SkillOn = false;
    bool SkillOn1 = false;
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
                case "CFX2_Wandering_Spirits":
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
                        SkillOn = true;
                        GameObject Effect3 = Resources.Load<GameObject>("Effect/" + SkillName);
                        GameObject Pos3 = Instantiate(Effect3, transform.parent.GetChild(1).transform);
                        Pos3.transform.position = new Vector2(0, 2);
                        StartCoroutine(Damage(enemy, Pos3, "성기사", 0));
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
                        enemy.Damage(atk, 0);
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
                    if (enemy != null)
                    {
                        enemy.Damage(atk1 * 0.5f, 0);
                    }
                    yield return new WaitForSeconds(1);
                    TimeCount1++;
                }
                Destroy(prefab);
                SkillOn = false;
                break;
        }
    }

    public void skillon(string skillname)
    {
        SkillName = skillname;
        transform.position = new Vector2(1.32f, 0.5f);
    }
}
