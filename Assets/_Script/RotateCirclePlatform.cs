using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCirclePlatform : MonoBehaviour
{

    [SerializeField]
    private float SpeedRotation = 1;

    void FixedUpdate()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y, Time.deltaTime*SpeedRotation, Space.Self);
    }
}
