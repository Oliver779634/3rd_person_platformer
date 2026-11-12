using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winScript : MonoBehaviour
{




    public TextMeshProUGUI WinText;
    public MeshFilter WinObject;
    public bool hasGotten = false;
    public medalTrigger mdtrigger;

    public CanvasRenderer medalNo1;
    public CanvasRenderer medalNo2;
    public CanvasRenderer medalNo3;


    public CanvasRenderer medalYes1;
    public CanvasRenderer medalYes2;
    public CanvasRenderer medalYes3;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {


            
            WinText.fontSize = 72;
            Destroy(WinObject);
            hasGotten = true;


            if (mdtrigger.number1Collected == true) {

                medalYes1.gameObject.SetActive(true);



            }

            else if (mdtrigger.number1Collected!= false)
            {

                medalNo1.gameObject.SetActive(true);
            }
        }
    }


    private void Start()
    {
        medalNo1.gameObject.SetActive(false);
        medalNo2.gameObject.SetActive(false);
        medalNo3.gameObject.SetActive(false);
        medalYes1.gameObject.SetActive(false);
        medalYes2.gameObject.SetActive(false);
        medalYes3.gameObject.SetActive(false);
    }


    private void Update()
    {
        Debug.Log("coin1: " + mdtrigger.number1Collected);
        Debug.Log("coin2: " + mdtrigger.number2Collected);
    }
}
