using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;


public class BattleGear_Sword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        var damage = DataManager.Instance.GetUnitData(Job.Unit13);
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                enemy.Damage(damage.Atk * 5, 1);
                StartCoroutine(StunDelay(enemy));
            }
        }
    }

    IEnumerator StunDelay(EnemyFsm enemy)
    {
        yield return new WaitForSeconds(1);
        if (enemy != null)
            enemy.StartCoroutine(enemy.State("Stun", 2));
    }

    private void Start()
    {
        Destroy(gameObject, 1.8f);
    }
}
