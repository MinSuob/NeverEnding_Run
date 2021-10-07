using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : MonoBehaviour
{
    float time = 0;

    private void Start()
    {
        StartCoroutine(Drop());
    }
    private void Update()
    {
    }
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(1);
        while (time < 1)
        {
            time += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, new Vector2(-2, 5), time / 10);
            yield return null;
        }
        Destroy(gameObject);
    }
}
