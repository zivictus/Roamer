using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float RotationSpeed;

    Spin()
    {
        RotationSpeed = 1.0f;
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotationSpeed, RotationSpeed, RotationSpeed);
    }
}
