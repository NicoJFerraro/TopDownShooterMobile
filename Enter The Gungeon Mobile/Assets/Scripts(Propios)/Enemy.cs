using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public Transform target;
    private NavMeshAgent _agent;
    public LayerMask layerMask;
    public float range;

    public int life;
    public Door _door;

    void Start() {
        _agent = GetComponent<NavMeshAgent>();

        _door = FindObjectOfType<Door>();

        _door.cantDeEnemigos++;
    }

    void Update() {
       

        if (CameraControl.killThem)
        {
            _door.CheckEnemies();
            Destroy(gameObject);
        }
        if (CameraControl.blinded)
        {
            target = null;
        }
        else
        { 
            if (target != null && !CameraControl.blinded)
            {
                _agent.destination = target.position;
            }
            SearchTarget();      
        }
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

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawSphere(transform.position, range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            life--;
            if (life <= 0)
            {
                _door.CheckEnemies();
                Destroy(gameObject);
            }
        }
    }
}