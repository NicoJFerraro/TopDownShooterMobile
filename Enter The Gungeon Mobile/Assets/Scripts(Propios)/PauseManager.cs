using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public Button toggle;
    public GameObject pauseMenu;
    public GameObject joy1;
    public GameObject joy2;
    public GameObject resumeBtn;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void TogglePause()
    {
        toggle.gameObject.SetActive(false);
        joy1.SetActive(false);
        joy2.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        toggle.gameObject.SetActive(true);
        joy1.SetActive(true);
        joy2.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void DeadPJ()
    {
        TogglePause();
        Time.timeScale = 1;
        resumeBtn.SetActive(false);

    }
}
