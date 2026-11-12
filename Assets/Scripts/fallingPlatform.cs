using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class fallingPlatform : MonoBehaviour
    
{




    public Rigidbody rb;
    public Transform platformCollider;

    private float timer = 3;
    public Vector3 StartingPosition;
    public bool resetting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
        StartingPosition= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (resetting == true)
        {
            if (timer != 0)
            {
                timer -= 1 * Time.deltaTime;
                
            }

            if (timer < 0)
            {
                rb.useGravity = false;
                rb.position = StartingPosition;
                resetting = false;
                timer = 3;
            }
        }

    }



    

    private void resetPlatform()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.useGravity=true;

            resetting = true;
        }
    }
}

