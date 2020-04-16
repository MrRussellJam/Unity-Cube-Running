using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform body = null;

    public float x = 0;
    public float y = 1f;
    public float z = -4.5f;


    public void  FixedUpdate()
    {
        transform.position = body.position + new Vector3(x, y, z);
    }
}
