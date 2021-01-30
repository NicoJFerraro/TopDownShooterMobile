using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBase : MonoBehaviour {

    Door _d;

    private void Start()
    {
        _d = FindObjectOfType<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 && _d.cantDeEnemigos <= 0)
        {          
            _d.StartAnimation();
        }
    }
}
