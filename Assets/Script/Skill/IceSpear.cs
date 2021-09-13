using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class IceSpear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            var damage = DataManager.Instance.GetUnitData(Job.Unit3);
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                enemy.Damage(damage.Atk * 1.5f, 0);
                enemy.StartCoroutine(enemy.State("Ice", 2));
            }
        }
    }
}