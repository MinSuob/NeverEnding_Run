using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Player)
    {
        EnemyFsm enemyfsm = gameObject.transform.parent.gameObject.GetComponent<EnemyFsm>();

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
}
