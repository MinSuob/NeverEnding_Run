using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class EnemyFsm : MonoBehaviour
{
    [SerializeField] private EnemyJob job;
    SPUM_Prefabs _prefabs;

    EnemyData enemy;

    public bool Fight = false;

    [SerializeField] private Slider HpBar;

    float MaxHp;
    [HideInInspector] public float CurHp;

    StageManager sm;

    void Start()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        _prefabs = gameObject.GetComponent<SPUM_Prefabs>();
        _prefabs.PlayAnimation(1);

        enemy = DataManager.Instance.GetEnemyData(job);

        MaxHp = enemy.MaxHp;
        CurHp = enemy.CurHp;

        HpBar.value = CurHp / MaxHp;

    }

    void Update()
    {
        if (!Fight)
        {
            Move(enemy.MoveSpeed);
        }
    }

    void Move(float Speed)
    {
        transform.Translate(Vector2.left * Speed);
    }

    public IEnumerator Attack(Collider2D Player)
    {
        UnitFsm unitfsm = Player.GetComponent<UnitFsm>();

        while (true)
        {
            switch (enemy.AtkType)
            {
                case "Melee":
                    if (Player != null)
                    {
                        _prefabs.PlayAnimation(4);
                        unitfsm.Damage(enemy.Atk, 0.2f);
                    }
                    break;
                case "Bow":
                    if (Player != null)
                    {
                        _prefabs.PlayAnimation(5);
                        unitfsm.Damage(enemy.Atk, 0.5f);
                    }
                    break;
                case "Magic":
                    if (Player != null)
                    {
                        _prefabs.PlayAnimation(6);
                        unitfsm.Damage(enemy.Atk, 0.2f);
                    }
                    break;
            }
            yield return new WaitForSeconds(enemy.AtkDelay);
        }
    }

    public void Damage(float damage, float Delay)
    {
        CurHp -= damage;
        StartCoroutine(DamageDelay(Delay));
    }

    IEnumerator DamageDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HpBar.value = CurHp / MaxHp;
        if (CurHp <= 0)
        {
            sm.EnemyCurCount--;
            if (sm.StageProgress == false && sm.EnemyCurCount == 0)
            {
                sm.StagePanel("Clear");
            }
            Destroy(gameObject);
        }
    }
}
