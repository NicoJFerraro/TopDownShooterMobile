using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Enemy {

    private NavMeshAgent _bossAgent;

    public float spawnCd;
    private float _countDown;

    public Enemy _enemy;

    private float _iS;
    private bool _s;

    public GameObject normalBullet;

    public float tiempoLogro;

    private AudioSource _au;
    public AudioClip auClip;
    public AudioClip auClip2;
    void Start () {
        _door = FindObjectOfType<Door>();
        _door.cantDeEnemigos++;
        _bossAgent = GetComponent<NavMeshAgent>();
        _iS = GetComponent<NavMeshAgent>().speed;
        _countDown = spawnCd;
        _s = true;
        _au = GetComponent<AudioSource>();
    }

    void Update () {

        if (target != null)
        {
            _countDown -= Time.deltaTime;

            _bossAgent.destination = target.position;
            if (_s)
            {
                StartCoroutine(ShootTrackingBullets());
                _s = false;
            }

            tiempoLogro -= Time.deltaTime;
            if (tiempoLogro < 0)
            {
                Achievements.logro2 = false;
            }
        }
        else
            SearchTarget();

    }

    IEnumerator SpawnLilBoys()
    {
        GetComponent<NavMeshAgent>().speed = 0;
        yield return new WaitForSeconds(spawnCd);
        var enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.target = target;
        _countDown = spawnCd;
        StartCoroutine(NormalFire());
        GetComponent<NavMeshAgent>().speed = _iS;

    }

    public IEnumerator ShootTrackingBullets()
    {
        yield return new WaitForSeconds(3f);
        // Es un tiempo de receso
       // var _2tb = Instantiate(tb, transform.position, Quaternion.identity);
      //  _2tb.target = target;

        StartCoroutine(NormalFire());
    }

    public IEnumerator NormalFire()
    {
        yield return new WaitForSeconds(1f);

        var _nb = Instantiate(normalBullet, transform.position, Quaternion.identity);
        _nb.transform.LookAt(target);
        _au.PlayOneShot(auClip);
        StartCoroutine(SpawnLilBoys());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            life--;
            if (life <= 0)
            {
                Death();
                _door.cantDeEnemigos--;
            }
        }
    }

    void Death()
    {
        GetComponent<NavMeshAgent>().speed = 0;
        _au.PlayOneShot(auClip2);
        Achievements.logro3 = true;

        Destroy(gameObject,1);
    }
}
