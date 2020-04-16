using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Cam : MonoBehaviour
{

    public Transform CanObj;
    private Vector3 Rotation_Transform;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        Rotation_Transform = CanObj.position;
    }

    // Update is called once per frame
    void Update()
    {
        var mouse_x = Input.GetAxis("Mouse X");
        var mouse_y = -Input.GetAxis("Mouse Y");
        transform.RotateAround(Rotation_Transform, Vector3.up, mouse_x * 5);
        transform.RotateAround(Rotation_Transform, transform.right, mouse_y * 5);
    }
}
