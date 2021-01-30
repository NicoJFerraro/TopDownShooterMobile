using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody _rb;


    public float _lt = 5;

    public float speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;

        StartCoroutine(Death());
 
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    public void Deactivate()
    {
        _lt = 0;
        Destroy(gameObject);
    }

    public IEnumerator Death()
    {

        yield return new WaitForSeconds(_lt);
        _rb.isKinematic = true;                                                              
        Deactivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        Deactivate();

    }
    private void OnCollisionEnter(Collision collision)
    {
        Deactivate();
    }

}
