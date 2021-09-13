using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class BladeStorm : MonoBehaviour
{
    public GameObject explosion;
    private void Start()
    {
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3);
        explosion.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
