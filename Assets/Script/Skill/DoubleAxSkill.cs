using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAxSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                enemy.Damage(GameObject.Find("Unit10(Clone)").GetComponent<UnitFsm>().unit.Atk * 2.5f, 0);
                enemy.StartCoroutine(enemy.State("Stun", 2));
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
