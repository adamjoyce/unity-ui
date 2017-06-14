using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 100.0f;                     // The speed at which the object will rotate.

    /* Update is called once per frame. */
    void Update()
    {
        transform.Rotate((Vector3.up * rotationSpeed) * Time.deltaTime);
    }
}