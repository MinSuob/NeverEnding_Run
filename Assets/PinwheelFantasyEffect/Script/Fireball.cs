using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Fireball : MonoBehaviour {
    public bool pushOnAwake = true;
    public Vector3 startDirection;
    public float startMagnitude;
    public ForceMode2D forceMode;

    public GameObject fieryEffect;
    public GameObject smokeEffect;
    public GameObject explodeEffect;

    protected Rigidbody2D rgbd;

    public void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        if (pushOnAwake)
        {
            Push(startDirection, startMagnitude);
        }
    }

    public void Push(Vector3 direction, float magnitude)
    {
        Vector3 dir = direction.normalized;
        rgbd.AddForce(dir * magnitude,ForceMode2D.Force);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            rgbd.Sleep();
            if (fieryEffect != null)
            {
                StopParticleSystem(fieryEffect);
            }
            if (smokeEffect != null)
            {
                StopParticleSystem(smokeEffect);
            }
            if (explodeEffect != null)
            {
                explodeEffect.transform.position = col.transform.position;
                explodeEffect.SetActive(true);
            }
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public void StopParticleSystem(GameObject g)
    {
        ParticleSystem[] par;
        par = g.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem p in par)
        {
            p.Stop();
        }
    }

    public void OnEnable()
    {
        if (fieryEffect != null)
            fieryEffect.SetActive(true);
        if (smokeEffect != null)
            smokeEffect.SetActive(true);
        if (explodeEffect != null)
            explodeEffect.SetActive(false);
    }
}


