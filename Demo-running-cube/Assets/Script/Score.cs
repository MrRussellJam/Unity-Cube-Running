using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text StatusText;


	
	// Update is called once per frame
	void Update () {
        StatusText.text = (player.position.z+65.7).ToString("0");
	}
}
