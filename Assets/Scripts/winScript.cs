using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winScript : MonoBehaviour
{




    public TextMeshProUGUI WinText;
    public MeshFilter WinObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {


            Debug.Log("win");
            WinText.fontSize = 72;
            Destroy(WinObject);
            
        }
    }
}
