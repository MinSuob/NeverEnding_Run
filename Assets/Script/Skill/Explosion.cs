using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                var damage = DataManager.Instance.GetUnitData(Job.Unit26);
                enemy.Damage(damage.Atk * 10, 0);
                StartCoroutine(destroy());
            }
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
