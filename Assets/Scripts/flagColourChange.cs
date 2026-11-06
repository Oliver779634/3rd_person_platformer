using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagColourChange : MonoBehaviour
{

    public Checkpoint check;

    

    // Update is called once per frame
    void Update()
    {
        if (check.gotten == true) {

            Material mat = GetComponent<Renderer>().material;
            Color baseColour = mat.color;
            baseColour.r = 0.0f;
            baseColour.g = 1.0f;
            baseColour.b = 0.0f;
            mat.color= baseColour;
        }

    }
}
