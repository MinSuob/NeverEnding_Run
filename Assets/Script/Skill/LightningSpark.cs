using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpark : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                enemy.Damage(GameObject.Find("Unit5(Clone)").GetComponent<UnitFsm>().unit.Atk * 2, 0);
                enemy.StartCoroutine(enemy.State("Stun", 2));
            }
        }
    }

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}
