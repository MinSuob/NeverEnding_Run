using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                Enemy.GetComponent<EnemyFsm>().Damage(GameObject.Find("Unit9(Clone)").GetComponent<UnitFsm>().unit.Atk * 1.2f, 0);
            }
        }
    }

    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * 0.05f);
    }
}
