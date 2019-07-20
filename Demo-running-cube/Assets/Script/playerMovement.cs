using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public Rigidbody rb;

    public static float forwardForce = 600f;

    public static float moveForce = 500f;

    public static float SvipForce = 600f;
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(0, 0, forwardForce*Time.deltaTime);
        if (Input.GetKey("a"))
            rb.AddForce(-moveForce * Time.deltaTime, 0, 0);
        if (Input.GetKey("d"))
            rb.AddForce(moveForce * Time.deltaTime, 0, 0);
        if (Input.GetKey("w"))
            rb.AddForce(0, 0, moveForce * Time.deltaTime);
        if (Input.GetKey("s"))
            rb.AddForce(0, 0, -SvipForce * Time.deltaTime);
	}
}
