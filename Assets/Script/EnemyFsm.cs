﻿using System.Collections;
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

    [HideInInspector] public bool[] enemystate = { false };


    void Start()
    {
        sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        _prefabs = gameObject.GetComponent<SPUM_Prefabs>();
        _prefabs.PlayAnimation(1);
        Box = gameObject.transform.GetChild(2).gameObject.GetComponent<EnemyDistanceBox>();
        enemy = DataManager.Instance.GetEnemyData(job);

        MaxHp = enemy.MaxHp;
        CurHp = enemy.CurHp;

        HpBar.value = CurHp / MaxHp;

    }

    void Update()
    {
        print(enemystate[0]);
        if (enemystate[0] == true)
            _prefabs.PlayAnimation(3);
        else
        {
            if (!Fight)
            {
                Move(enemy.MoveSpeed);
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
                print("sef");

                enemystate[0] = true;
                Box.DistanceSize.offset = new Vector2(1, 0);
                yield return new WaitForSeconds(time);
                enemystate[0] = false;
                _prefabs.PlayAnimation(1);
                Box.BoxSize();
                break;
        }
    }
}
