using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public Transform spawnPos;

    public float speed;
    public Rigidbody _rb;

    public GameObject bullet;

    private Vector3 lookV;
    public GameObject aim;

    public Joystick _jY;
    public Joystick _jY2;

    private float _fr;

    public float fireRate;
    private float _oFR;

    private AudioSource _au;

    public AudioClip auClip1;

    void Start() {
        _oFR = fireRate; 
        _rb = GetComponent<Rigidbody>();
        _au = GetComponent<AudioSource>();

        _fr = fireRate;
  
        Console.instance.RegisterCommand("NoFireRate", NoFireRate, "Disparas full auto");
    }

    private void FixedUpdate()
    {     
        _rb.velocity = new Vector3(_jY2.stickValue.y * speed, _rb.velocity.y, _jY2.stickValue.x * speed *-1);       
    }
    void NoFireRate()
    {
        if (fireRate == 0)
        {
            fireRate = _oFR;
        }
        else
        {
            fireRate = 0;
        }
    }
    private void Update()
    {
            Vector3 lookV = (new Vector3(_jY.stickValue.y, 0, _jY.stickValue.x * -1)) * 10;

            if (lookV.x != 0 || lookV.z != 0)
                FireRate();

            aim.transform.position = transform.position + lookV;

            transform.LookAt(aim.transform.position);

            _fr -= Time.deltaTime;   
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, aim.transform.position, Color.yellow);
    }

    void FireRate()
    {
        if (_fr <= 0)
        {
            var _b =  Instantiate(bullet, spawnPos.position, Quaternion.identity);
            _b.transform.rotation = transform.rotation;
            _fr = fireRate;
            _au.volume = 0.023f;
            _au.PlayOneShot(auClip1);

        }
    }
}





