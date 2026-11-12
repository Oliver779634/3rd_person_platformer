using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medalTrigger : MonoBehaviour
{

    public MeshFilter medalMesh;
    public int collectableNumber;



    public bool number1Collected = false;
    public bool number2Collected = false;
    public bool number3Collected = false;



    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Destroy(medalMesh);

            if (collectableNumber == 1)
            {
                number1Collected= true;
                Debug.Log("collect1");
            }


            else if (collectableNumber == 2)
            {
                number2Collected = true;
                Debug.Log("collect2");
            }


            else if (collectableNumber == 3)
            {
                number3Collected = true;
            }


            
        }
    }


    private void Update()
    {
        //Debug.Log(number1Collected);
    }

}




