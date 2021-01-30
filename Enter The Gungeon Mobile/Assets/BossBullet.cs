using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bullet {

    public float magnitude;

    public float frequency;

    Vector3 pos;

    void Start () {

        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;

        pos = transform.position;
        StartCoroutine(Death());
	}

    private void Update()
    {
        pos += transform.forward * Time.deltaTime * speed;
        transform.position = pos + transform.right * Mathf.Cos(Time.time * frequency) * magnitude;
       
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        print("ASDASDASDasdASDASdASd");
        Deactivate();

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("CHOQUE");
        Deactivate();
    }
}
