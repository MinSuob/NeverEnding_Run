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
    int curStage;

    public bool Fight = false;

    [SerializeField] private Slider HpBar;

    float MaxHp;
    [HideInInspector] public float CurHp;
    float atk;
    int dropGold;

    StageManager sm;
    [HideInInspector] public EnemyDistanceBox Box;

    bool[] enemystate = { false, false, false };
    float moveSpeed;
    [SerializeField] Transform Body;
    SpriteRenderer[] srs;
    float aniSpeed;

    [SerializeField] private GameObject goldimg;
    float stagIncrease = 0;

    void Start()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        _prefabs = gameObject.GetComponent<SPUM_Prefabs>();
        
        _prefabs.PlayAnimation(1);
        Box = gameObject.transform.GetChild(2).gameObject.GetComponent<EnemyDistanceBox>();
        enemy = DataManager.Instance.GetEnemyData(job);
        curStage = DataManager.Instance.GetCurStage();
        srs = Body.GetComponentsInChildren<SpriteRenderer>();

        aniSpeed = _prefabs._anim.speed;
        moveSpeed = enemy.MoveSpeed;

        if (curStage > 1)
        {
            SetStat();
        }
        else
        {
            MaxHp = enemy.MaxHp;
            CurHp = MaxHp;
            atk = enemy.Atk;
            dropGold = enemy.DropGold;
        }
        HpBar.value = CurHp / MaxHp;
    }

    void SetStat()
    {
        for (float i = 1; i <= curStage; i++)
        {
            MaxHp = enemy.MaxHp * (1 + (i / 10));
            atk = enemy.Atk * 1 + ((i / 10));
            dropGold = enemy.DropGold * (1 + ((int)i / 5));
        }
        CurHp = MaxHp;
    }

    void Update()
    {
        //GetComponent<Monster>().Animator.speed = Param.AniSpd * coldSpd;
        
        if (!Fight && enemystate[0] == false)
        {
            Move(moveSpeed);
        }

        if (enemystate[0] == true)
            _prefabs.PlayAnimation(3); // 스턴
        else if (enemystate[1] == true) // 빙결
        {
            moveSpeed = enemy.MoveSpeed / 3;
            _prefabs._anim.speed = aniSpeed / 2;
            for (int i = 0; i < srs.Length; i++)
            {
                srs[i].color = new Color(50 / 255f, 50 / 255f, 255 / 255f);
            }
        }
        else if (enemystate[2] == true) // 중독
        {
            for (int i = 0; i < srs.Length; i++)
            {
                srs[i].color = new Color(255 / 255f, 30 / 255f, 150 / 255f);
                if (srs[i].name == "Front")
                {
                    srs[i].color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 232 / 255f);
                }
                if (srs[i].name == "Shadow")
                {
                    srs[i].color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 143 / 255f);
                }
            }
        }
        else
        {
            moveSpeed = enemy.MoveSpeed;
            _prefabs._anim.speed = aniSpeed;
            for (int i = 0; i < srs.Length; i++)
            {
                if (srs[i].name != "Front")
                {
                    srs[i].color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
                }
                if (srs[i].name == "Shadow")
                {
                    srs[i].color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 143 / 255f);
                }
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
            _prefabs.PlayAnimation(2);
            GameObject dropimg = null;
            dropimg = Instantiate(goldimg, transform.parent.gameObject.transform);
            dropimg.transform.localPosition = new Vector3(transform.position.x - 3.5f, transform.position.y - 0.4f, 1);
            sm.StartCoroutine(sm.TakeGold(dropGold));
            yield return new WaitForSeconds(0.5f);
            sm.EnemyCurCount--;
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
                yield return new WaitForSeconds(time);
                enemystate[1] = false;
                break;
            case "Poison":
                enemystate[2] = true;
                yield return new WaitForSeconds(time);
                enemystate[2] = false;
                break;
        }
    }
}
