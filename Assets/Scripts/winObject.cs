using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public float spinAmount = 0.5f;

    private void Update()
    {
        transform.Rotate(0, 0, (-1*spinAmount));
    }
}
