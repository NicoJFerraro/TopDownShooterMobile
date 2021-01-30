using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;

public class Botones : MonoBehaviour {

    public GameObject console;
    private bool _seenAdv;

    private void Start()
    {
        _seenAdv = false;
    }

    public void PlayScene()
    {
        if (Advertisement.IsReady() && !_seenAdv)
        {
            //Advertisement.Show();
            AnalyticsEvent.AdStart(false);
            _seenAdv = true;
        }
        else 
        {
            AnalyticsEvent.GameStart();
            SceneManager.LoadScene(2);
        }
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 2 && SceneManager.GetActiveScene().buildIndex != 5)
        {
            AnalyticsEvent.LevelQuit(SceneManager.GetActiveScene().name);
        }
        SceneManager.LoadScene(0);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OpenConsole()
    {
        if (console.activeInHierarchy == true)
            console.SetActive(false);
        else
        {
            console.SetActive(true);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
