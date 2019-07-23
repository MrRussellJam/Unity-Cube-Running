using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Rigidbody Player;

    public float moveForce = 30f;

	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            Player.AddForce(0, 0, moveForce * 100);
        if (Input.GetKey("s"))
            Player.AddForce(0, 0, -moveForce * 100);
        if (Input.GetKey("d"))
            Player.AddForce(moveForce * 100, 0, 0);
        if (Input.GetKey("a"))
            Player.AddForce(-moveForce * 100, 0, 0);
    }
}
