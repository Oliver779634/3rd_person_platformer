using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public bool gotten = false;


    public PlayerController controller;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            controller.respawnPos = transform.position;
            gotten= true;
        }
    }
}
