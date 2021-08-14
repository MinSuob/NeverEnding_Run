using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class UnitFsm : MonoBehaviour
{
    public Job job;
    SPUM_Prefabs _prefabs;
    [HideInInspector] public UnitData unit;

    public bool Fight_On = false;


    private void Start()
    {
        _prefabs = gameObject.GetComponent<SPUM_Prefabs>();
         unit = DataManager.Instance.GetUnitData(job);

    }

    private void Update()
    {

    }

    public IEnumerator Attack(Collider2D Enemy)
    {
        while (true)
        {
            if (Fight_On)
            {
                switch (unit.AtkType)
                {
                    case "Melee":
                        _prefabs.PlayAnimation(4);
                        if (Enemy != null)
                        {
                            Enemy.GetComponent<EnemyFsm>().Damage(unit.Atk);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "Bow":
                        _prefabs.PlayAnimation(5);
                        if (Enemy != null)
                        {
                            Enemy.GetComponent<EnemyFsm>().Damage(unit.Atk);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "Magic":
                        _prefabs.PlayAnimation(6);
                        if (Enemy != null)
                        {
                            Enemy.GetComponent<EnemyFsm>().Damage(unit.Atk);
                        }
                        else
                        {
                            break;
                        }
                        break;
                }
            }
            yield return new WaitForSeconds(unit.AtkDelay);
        }
    }
}
