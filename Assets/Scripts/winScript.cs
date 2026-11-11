using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winScript : MonoBehaviour
{




    public TextMeshProUGUI WinText;
    public MeshFilter WinObject;
    public bool hasGotten = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {


            
            WinText.fontSize = 72;
            Destroy(WinObject);
            hasGotten = true;
            
        }
    }
}
