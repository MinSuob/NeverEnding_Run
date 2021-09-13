using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class FireWall : MonoBehaviour
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
        var damage = DataManager.Instance.GetUnitData(Job.Unit4);
        int count = 0;
        while (count < 3)
        {
            if (enemy != null)
                enemy.Damage(damage.Atk / 2, 0);
            yield return new WaitForSeconds(1);
            count++;
        }
        GameObject Effect = Resources.Load<GameObject>("Effect/" + "CFX3_Fire_Explosion");
        GameObject Pos = Instantiate(Effect, gameObject.transform.parent.transform);
        Pos.transform.position = transform.position;
        //if (enemy != null)
        //    enemy.Damage(GameObject.Find("Unit4(Clone)").GetComponent<UnitFsm>().unit.Atk, 0);
        Destroy(gameObject);
    }
}
