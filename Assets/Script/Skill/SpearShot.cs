﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class SpearShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        var damage = DataManager.Instance.GetUnitData(Job.Unit9);
        if (Enemy.tag == "Enemy")
        {
            EnemyFsm enemy = Enemy.GetComponent<EnemyFsm>();
            if (enemy != null)
            {
                Enemy.GetComponent<EnemyFsm>().Damage(damage.Atk, 0);
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
