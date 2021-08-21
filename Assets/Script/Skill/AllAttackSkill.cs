using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAttackSkill : MonoBehaviour
{
    bool SkillOn = false;
    string SkillName;

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
                    if (enemy != null)
                    {
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
                int TimeCount = 0;
                while (TimeCount < 5)
                {
                    enemy.Damage(GameObject.Find("Unit6(Clone)").GetComponent<UnitFsm>().unit.Atk, 0);
                    yield return new WaitForSeconds(1);
                    TimeCount++;
                }
                Destroy(prefab);
                break;
        }
    }

    public void skillon(string skillname)
    {
        SkillName = skillname;
        transform.position = new Vector2(1.32f, 0.5f);
    }
}
