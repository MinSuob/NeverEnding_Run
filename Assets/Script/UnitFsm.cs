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
    UnitDistanceBox Box;

    private List<string> DeckData = new List<string>();
    StageManager sm;

    int MySlotNum;

    [HideInInspector] public float MaxHp;
    [HideInInspector] public float CurHp;

    private void Start()
    {
        DeckData = DataManager.Instance.GetDeckData();
        _prefabs = gameObject.GetComponent<SPUM_Prefabs>();
         unit = DataManager.Instance.GetUnitData(job);
        Box = gameObject.transform.GetChild(2).gameObject.GetComponent<UnitDistanceBox>();
        
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
        EnemyFsm enemyFsm = Enemy.GetComponent<EnemyFsm>();

        while (Fight_On)
        {
            switch (unit.AtkType)
            {
                case "Melee":
                    if (Enemy != null)
                    {
                        _prefabs.PlayAnimation(4);
                        enemyFsm.Damage(unit.Atk, 0.2f);
                        if (enemyFsm.CurHp <= 0)
                        {
                            yield return new WaitForSeconds(unit.AtkDelay);
                            Fight_On = false;
                            Box.ReSize();
                        }
                    }
                    break;
                case "Bow":
                    if (Enemy != null)
                    {
                        _prefabs.PlayAnimation(5);
                        enemyFsm.Damage(unit.Atk, 0.5f);
                        if (enemyFsm.CurHp <= 0)
                        {
                            yield return new WaitForSeconds(unit.AtkDelay);
                            Fight_On = false;
                            Box.ReSize();
                        }
                    }
                    break;
                case "Magic":
                    if (Enemy != null)
                    {
                        _prefabs.PlayAnimation(6);
                        enemyFsm.Damage(unit.Atk, 0.2f);
                        if (enemyFsm.CurHp <= 0)
                        {
                            yield return new WaitForSeconds(unit.AtkDelay);
                            Fight_On = false;
                            Box.ReSize();
                        }
                    }
                    break;
            }
            yield return new WaitForSeconds(unit.AtkDelay);
        }
    }

    public void HpSet(float curHp)
    {
        MySlotNum = DeckData.FindIndex(num => num.Contains(job.ToString()));

        if (MySlotNum == 0 && sm.CurHp[0] != sm.MaxHp[0])
        {
            CurHp = sm.CurHp[0];
        }

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
}
