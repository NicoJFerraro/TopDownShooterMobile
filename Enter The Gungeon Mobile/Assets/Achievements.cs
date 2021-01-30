using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Achievements : MonoBehaviour {


    public static bool logro1; // Terminar sin recibir ningun tipo de daño
    public static bool logro2; // Terminar el boss en cierta cantidad de tiempo
    public static bool logro3; // Matar al boss
    public static bool logro4; // Ganar el ultimo nivel sin recibir daño
    public static bool logro5; // Ganar el juego sin recibir daño de balas

    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    public GameObject texto4;
    public GameObject texto5;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            texto1.gameObject.SetActive(logro1);
            texto2.gameObject.SetActive(logro2);
            texto3.gameObject.SetActive(logro3);
            texto4.gameObject.SetActive(logro4);
            texto5.gameObject.SetActive(logro5);
        }
    }

    public void NewGame()
    {
        logro1 = true;
        logro2 = true;
        logro3 = false;
        logro4 = true;
        logro5 = true;
    }
}
