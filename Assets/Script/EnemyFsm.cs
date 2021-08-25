using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterState;


public class EnemyFsm : MonoBehaviour
{
    public EnemyJob job;
    [HideInInspector] public SPUM_Prefabs _prefabs;

    EnemyData enemy;

    public bool Fight = false;

    [SerializeField] private Slider HpBar;

    float MaxHp;
    [HideInInspector] public float CurHp;

    StageManager sm;
    [HideInInspector] public EnemyDistanceBox Box;

    bool[] enemystate = { false, false };
    float moveSpeed;
    float SlowSpeed;
    [SerializeField] Transform Body;

    void Start()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        _prefabs = gameObject.GetComponent<SPUM_Prefabs>();
        _prefabs.PlayAnimation(1);
        Box = gameObject.transform.GetChild(2).gameObject.GetComponent<EnemyDistanceBox>();
        enemy = DataManager.Instance.GetEnemyData(job);
        moveSpeed = enemy.MoveSpeed;
        SlowSpeed = moveSpeed / 2;
        MaxHp = enemy.MaxHp;
        CurHp = enemy.CurHp;

        HpBar.value = CurHp / MaxHp;
    }

    void Update()
    {
        //GetComponent<Monster>().Animator.speed = Param.AniSpd * coldSpd;

        if (enemystate[0] == true)
            _prefabs.PlayAnimation(3);
        else
        {
            if (!Fight)
            {
                Move(moveSpeed);
            }
        }
    }

    void Move(float Speed)
    {
        transform.Translate(Vector2.left * Speed);
    }

    public IEnumerator Attack(Collider2D Player)
    {
        UnitFsm unitfsm = Player.GetComponent<UnitFsm>();

        while (enemystate[0] == false)
        {
            switch (enemy.AtkType)
            {
                case "Melee":
                    if (Player != null)
                    {
                        _prefabs.PlayAnimation(4);
                        if (sm.CurHpSum > 0)
                        {
                            unitfsm.Damage(enemy.Atk, 0.2f);
                        }
                    }
                    break;
                case "Bow":
                    if (Player != null)
                    {
                        _prefabs.PlayAnimation(5);
                        if (sm.CurHpSum > 0)
                        {
                            unitfsm.Damage(enemy.Atk, 0.2f);
                        }
                    }
                    break;
                case "Magic":
                    if (Player != null)
                    {
                        _prefabs.PlayAnimation(6);
                        if (sm.CurHpSum > 0)
                        {
                            unitfsm.Damage(enemy.Atk, 0.2f);
                        }
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

    public IEnumerator State(string state, float time)
    {
        switch (state)
        {
            case "Stun":
                enemystate[0] = true;
                Box.DistanceSize.offset = new Vector2(1, 0);
                yield return new WaitForSeconds(time);
                enemystate[0] = false;
                _prefabs.PlayAnimation(1);
                Box.BoxSize();
                break;
            case "Ice":
                enemystate[1] = true;
                moveSpeed = enemy.MoveSpeed / 2;
                SpriteRenderer[] srs = Body.GetComponentsInChildren<SpriteRenderer>();
                for (int i = 0; i < srs.Length; i++)
                {
                    srs[i].color = new Color(50 / 255f, 50 / 255f, 255 / 255);
                }
                yield return new WaitForSeconds(time);
                for (int i = 0; i < srs.Length; i++)
                {
                    if (srs[i].name != "Front")
                    {
                        srs[i].color = new Color(255 / 255f, 255 / 255f, 255 / 255);
                    }
                    if (srs[i].name == "Shadow")
                    {
                        srs[i].color = new Color(0 / 255f, 0 / 255f, 0 / 255, 143 / 255f);
                    }
                }
                enemystate[1] = false;
                moveSpeed = enemy.MoveSpeed;
                break;
        }
    }
}
