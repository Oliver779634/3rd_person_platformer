using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winObject : MonoBehaviour
{
    public float spinAmount = 0.5f;

    public void Update()
    {
        transform.Rotate(0, 0, (-1*spinAmount));
    }
}
