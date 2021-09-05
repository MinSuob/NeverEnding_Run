using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class FireWall2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                var damage = DataManager.Instance.GetUnitData(Job.Unit4);
                enemy.Damage(damage.Atk, 0);
            }
        }
    }
}