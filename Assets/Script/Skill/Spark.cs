using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class Spark : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        var damage = DataManager.Instance.GetUnitData(Job.Unit18);
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                enemy.Damage(damage.Atk * 3, 0);
                enemy.StartCoroutine(enemy.State("Stun", 2));
            }
        }
    }
}
