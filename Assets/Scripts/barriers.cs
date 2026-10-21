using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriers : MonoBehaviour
{
    public PlayerController player;
    public BoxCollider collision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(player.currentSpeed);

        if (player.velocity.x > 16){

            collision.enabled = false;

        }
        else
        {


            collision.enabled = true;
        }
    }
}
