using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class Shuriken : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Enemy")
        {
            StartCoroutine(Damage(Enemy.GetComponent<EnemyFsm>()));
        }
    }

    IEnumerator Damage(EnemyFsm enemy)
    {
        var damage = DataManager.Instance.GetUnitData(Job.Unit19);
        int count = 0;
        while (count < 3)
        {
            if (enemy != null)
                enemy.Damage(damage.Atk * 1.5f, 0);
            yield return new WaitForSeconds(1);
            count++;
        }
    }

    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.Translate(Vector2.right * 0.005f);
    }
}
