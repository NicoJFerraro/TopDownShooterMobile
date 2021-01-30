using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class Door : MonoBehaviour {

    private bool canPScene;

    public int nextScene;

    public int cantDeEnemigos = 0;

    public void CheckEnemies()
    {
        cantDeEnemigos--;

        if (cantDeEnemigos <= 0)
        {          
            canPScene = true;
        }
        print(cantDeEnemigos);
               
    }
    
    public void StartAnimation()
    {
        GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8 && canPScene)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                AnalyticsEvent.GameOver();
            }

            AnalyticsEvent.LevelComplete(SceneManager.GetActiveScene().name);

            SceneManager.LoadScene(nextScene);
        }
    }
}
