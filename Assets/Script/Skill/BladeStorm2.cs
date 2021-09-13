using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class BladeStorm2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                var damage = DataManager.Instance.GetUnitData(Job.Unit25);
                enemy.Damage(damage.Atk * 15, 0);
            }
        }
    }
}
