using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;

    public LayerMask layerMask;
    private bool _start;
    public float range;

    public int life;

    public GameObject bullet;

    public Transform spawnPos;

    public float fireRate;
    private float _fr;

    private AudioSource _au;
    public AudioClip auClip;

    private void Start()
    {
        _start = true;
        _au = GetComponent<AudioSource>();
        _fr = 0;
    }

    void Update()
    {
        SearchTarget();

        if (target != null && _start)
        {
            FireRate();
        }

        _fr -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        if(target)
            transform.LookAt(target);
    }

    public void SearchTarget()
    {
        Collider[] tg = Physics.OverlapSphere(transform.position, range, layerMask.value);
        for (int i = 0; i < tg.Length; i++)
        {
            if (tg[i] != null)
            {
                target = tg[i].gameObject.transform;
                i = tg.Length;
            }
        }
    }

    void FireRate()
    {
        if (_fr <= 0)
        {
            var _b = Instantiate(bullet, spawnPos.position, Quaternion.identity);
            _b.transform.rotation = transform.rotation;
            _fr = fireRate;
            _au.PlayOneShot(auClip);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
