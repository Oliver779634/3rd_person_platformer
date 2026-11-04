using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriers : MonoBehaviour
{
    public PlayerController player;
    public BoxCollider collision;
    public Material barrierMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //Material mat = GetComponent<Renderer>().material;
        //Color transparency = mat.color;
        //transparency.a = 0.5f;
        //mat.color = transparency;

    }

    // Update is called once per frame
    void Update()
    {

        



        if (player.isFast==true){

            collision.enabled = false;


            Material mat = GetComponent<Renderer>().material;
            Color baseColour = mat.color;
            baseColour.r = 0.0f;
            baseColour.g = 0.5f;
            baseColour.b = 0.5f;
            baseColour.a = 0.5f;
            mat.color = baseColour;

        }
        else
        {


            collision.enabled = true;

            Material mat = GetComponent<Renderer>().material;
            Color baseColour = mat.color;
            baseColour.r = 1.0f;
            baseColour.g = 0.0f;
            baseColour.b = 0.0f;
            baseColour.a = 0.5f;
            mat.color = baseColour;

        }
    }
}
 