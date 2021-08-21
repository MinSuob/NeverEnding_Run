using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceBox : MonoBehaviour
{
    EnemyFsm enemyfsm;
    [HideInInspector] public BoxCollider2D DistanceSize;


    private void Start()
    {
        enemyfsm = gameObject.transform.parent.gameObject.GetComponent<EnemyFsm>();
        DistanceSize = gameObject.GetComponent<BoxCollider2D>();

    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (enemyfsm.Fight == false)
        {
            if (Player.tag == "Player")
            {
                enemyfsm.Fight = true;
                enemyfsm.StartCoroutine(enemyfsm.Attack(Player));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D Player)
    {
        EnemyFsm enemyfsm = gameObject.transform.parent.gameObject.GetComponent<EnemyFsm>();

        if (Player.tag == "Player")
            enemyfsm.Fight = false;
    }

    public void BoxSize()
    {
        EnemyData enemy = DataManager.Instance.GetEnemyData(enemyfsm.job);

        if (enemy.AtkType == "Melee")
        {
            DistanceSize.offset = new Vector2(-0.5f, 0.25f);
            DistanceSize.size = new Vector2(0.1f, 1.1f);
        }
        else
        {
            DistanceSize.offset = new Vector2(-1.5f, 0.25f);
            DistanceSize.size = new Vector2(0.1f, 1.1f);
        }
    }
}
