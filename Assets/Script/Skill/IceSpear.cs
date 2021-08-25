using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                enemy.Damage(GameObject.Find("Unit3(Clone)").GetComponent<UnitFsm>().unit.Atk, 0);
                enemy.StartCoroutine(enemy.State("Ice", 2));
            }
        }
    }
}