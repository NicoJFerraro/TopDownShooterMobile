using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class PlayerHP : MonoBehaviour
{
    //AGREGAR HUD
    public int life;

    public int dmgR;

    public float timer;

    private bool _vul;
    private PauseManager _pm;

    public Text hP;

    public AudioSource _au;
    public AudioClip auClip2;

    private void Start()
    {
        hP.text = life.ToString();
        _pm = FindObjectOfType<PauseManager>();
        _au = GetComponent<AudioSource>();
        _vul = true;
        AnalyticsEvent.LevelStart(SceneManager.GetActiveScene().name);
        Console.instance.RegisterCommand("Inmunity", Inmunity, "Te hace invulnerable");
        Console.instance.RegisterCommand("No_Obstacles", NoCollision, "Atraviesas los obstaculos");
    }
    public void NoCollision()
    {
        if (gameObject.layer == 8)
        {
            gameObject.layer = 14;
        }
        else
        {
            gameObject.layer = 8;
        }
    }
    public void Inmunity()
    {
        if(_vul)
            _vul = false;
        else
        {
            _vul = true;
        }
    }
    void Damage()
    {
        _au.volume = 1f;
        _au.PlayOneShot(auClip2);

        Achievements.logro1 = false;
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            Achievements.logro4 = false;
        }
        life = life - dmgR;
        hP.text = life.ToString();
        if (life <= 0)
        {
            _au.volume = 1f;
            _au.PlayOneShot(auClip2);
            _pm.DeadPJ();
            gameObject.SetActive(false);
        }
        else
        {
            _vul = false;
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DmgAble());
        }      
    }

    IEnumerator DmgAble()
    {
        yield return new WaitForSeconds(timer);
        _vul = true;
        GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_vul == true)
        {
            if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
            {
                Damage();
            }
            if(collision.gameObject.layer == 12)
            {
                Achievements.logro5 = false;
                Damage();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_vul == true)
        {
            if (other.gameObject.layer == 10 || other.gameObject.layer == 11)
            {
                Damage();
            }
            
            if (other.gameObject.layer == 12)
            {
                Achievements.logro5 = false;
                Damage();
            }
        }
    }
}