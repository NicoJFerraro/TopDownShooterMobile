using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraControl : MonoBehaviour {

    public Transform pj;
    public float yOffset;
    public float xOffset;
    public float zOffset;
    public static bool _endcinema;
    public GameObject canvas;

    public static bool killThem;
    public static bool blinded;

    private void Awake()
    {
        killThem = false;
        blinded = false;
    }
    private void Start()
    {
        Console.instance.RegisterCommand("KillThemAll", KillThemAll, "Mata a todos los enemigos del nivel");
        killThem = false;
        blinded = false;

        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            _endcinema = true;
        }
        else
        {
            _endcinema = false;
        }
    }
    public void KillThemAll()
    {
        killThem = true;
    }
    public void Blinded()
    {
        blinded = true;
    }
    void LateUpdate () {
        if (SceneManager.GetActiveScene().buildIndex == 2 && !_endcinema)
        {
            canvas.SetActive(false);

            StartCoroutine(Cinematic());
        }
        else if (pj!= null)
        {
            transform.position = new Vector3(pj.position.x + xOffset , pj.position.y + yOffset, pj.position.z + zOffset);
            transform.LookAt(pj);
        }
    }
    IEnumerator Cinematic()
    {
        yield return new WaitForSeconds(5);
      
        if (transform.position.x <= -39)
        {
            _endcinema = true;
            canvas.SetActive(true);
        }
        else
        {
            transform.position = transform.position + new Vector3(-10, 0, 0) * Time.deltaTime;
        }

    }
}
