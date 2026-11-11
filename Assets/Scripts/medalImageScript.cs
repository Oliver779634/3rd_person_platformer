using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class medalImageScript : MonoBehaviour
{



    public int displayNumber;

    public medalTrigger trigger;


    public CanvasRenderer medalNo1;
    public CanvasRenderer medalNo2;
    public CanvasRenderer medalNo3;


    public CanvasRenderer medalYes1;
    public CanvasRenderer medalYes2;
    public CanvasRenderer medalYes3;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {



            if (displayNumber == 1)
            {

                if (trigger.number1Collected == true)
                {

                    Destroy(medalNo1);
                }

                if (trigger.number1Collected == false)
                {

                    Destroy(medalYes1);
                }
            }


            if (displayNumber == 2)
            {
                if (trigger.number2Collected == true)
                {

                    Destroy(medalNo2);
                }

                if (trigger.number2Collected == false)
                {

                    Destroy(medalYes2);
                }

            }

            if (displayNumber == 3)
            {
                if (trigger.number3Collected == true)
                {

                    Destroy(medalNo3);
                }

                if (trigger.number3Collected == false)
                {

                    Destroy(medalYes3);
                }

            }

        }
    }
}
