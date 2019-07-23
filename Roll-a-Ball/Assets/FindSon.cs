using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindSon : MonoBehaviour {

    public Text ScoreText;

	// Use this for initialization
	void Start () {

    }

    static int time = 1;

    // Update is called once per frame
    void Update () {
        GameObject gameObject = null;
        time++;
        gameObject = GameObject.FindGameObjectWithTag("food");
        try
        {
            Debug.Log(gameObject.ToString() + "  " + time.ToString());
        }
        catch(NullReferenceException)
        {
            Debug.Log("First Win");
            ScoreText.text = "You are win!";
        }
    }
}
