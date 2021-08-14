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
    float CurHp;

    void Start()
    {
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

    public IEnumerator Attack()
    {
        while (true)
        {
            switch (enemy.AtkType)
            {
                case "Melee":
                    _prefabs.PlayAnimation(4);
                    break;
                case "Bow":
                    _prefabs.PlayAnimation(5);
                    break;
                case "Magic":
                    _prefabs.PlayAnimation(6);
                    break;
            }
            yield return new WaitForSeconds(enemy.AtkDelay);
        }
    }

    public void Damage(float damage)
    {
        CurHp -= damage;
        HpBar.value = CurHp / MaxHp;

        print(damage);

        if (CurHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
